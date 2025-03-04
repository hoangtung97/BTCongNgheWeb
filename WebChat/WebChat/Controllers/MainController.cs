﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebChat.Models;
using WebChat.Models.CustomModel;
using System.Web.Security;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace WebChat.Controllers
{

    public class UserCredential
    {
        public static string getUSerID()
        {
            //FormsIdentity formsIdentity = HttpContext.Current.User.Identity as FormsIdentity;
            //FormsAuthenticationTicket ticket = formsIdentity.Ticket;

            //return ticket.UserData;
            HttpCookie authCookie = HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            return ticket.UserData;
        }
        public int userID;
        public UserCredential( int? id)
        {
            this.userID = Int32.Parse( id.ToString() );
        }
    }

    public class MainController : Controller
    {

        // GET: Main
        public ActionResult Main()
        {
            HttpCookie cookie = Request.Cookies["userID"];
            if (cookie == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            UserCredential currentUser = new UserCredential(Int32.Parse(cookie.Value));


            WebsocketManager.Manager.updateRoomsManager();
            WebsocketManager.Manager.updateDisplayNamesMapping();
            WebsocketManager.Manager.updateMappingRooms();
           
            //get all user in all room
            var Room_Users = Controllers.DbModuls.DbGet.GetRoom_Users();
            //get chat room user currently joined
            var ChatRoom = Controllers.DbModuls.DbGet.getUserRoomList(currentUser.userID);
            //get list of user join each room
            var AllUser = Controllers.DbModuls.DbGet.getUserList();

            ViewModel ViewModel1 = new ViewModel {ChatRoom = ChatRoom, Users = AllUser, Room_Users = Room_Users };

            return View(ViewModel1);
        }


        public ActionResult LogOut()
        {
            HttpCookie userID = Request.Cookies["userID"];
            HttpCookie displayName = Request.Cookies["displayName"];

            if( userID != null || displayName != null)
            {
                userID.Expires = DateTime.Now.AddDays(-1);
                displayName.Expires = DateTime.Now.AddDays(-1);

                Response.Cookies.Add(userID);
                Response.Cookies.Add(displayName);
            }

            return RedirectToAction("LogIn", "LogIn");
        }

        public string GetCookie(string name)
        {
            string cookie = this.GetCookie(name);
            return cookie;
        }

        public JsonResult GetConversations(int room)
        {
            List<Models.CustomModel.CustomConversations> getUserConversations = DbModuls.DbGet.getUserConversations(room);
            WebsocketManager.Manager.updateRoomsManager();
            WebsocketManager.Manager.updateDisplayNamesMapping();
            WebsocketManager.Manager.updateMappingRooms();
            return Json(getUserConversations, JsonRequestBehavior.AllowGet);
            
        }


        //CREATE, DELETE, EDIT METHODS

        //delelte user in room
        public void DeleteUserInRoom(int userid, int kickuserid, int roomid)
        {

            var adright = DbModuls.DbDelete.kickUser(userid, kickuserid, roomid);
            WebsocketManager.Manager.updateRoomsManager();
            WebsocketManager.Manager.updateDisplayNamesMapping();
            WebsocketManager.Manager.updateMappingRooms();
        }
        //leave room
        public void ExitRoom(int userid, int roomid)
        {
            DbModuls.DbDelete.leaveRoom(userid,roomid);
            WebsocketManager.Manager.updateRoomsManager();
            WebsocketManager.Manager.updateDisplayNamesMapping();
            WebsocketManager.Manager.updateMappingRooms();

        }

        //create room
        private static MD5 md5Hash = MD5.Create();
        static private string GetMd5Hash(string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public ActionResult CreateRoom()
        {
            string roomname = Request["roomname"];
            string roompw = GetMd5Hash(Request["roompw"]);

            HttpCookie cookie = Request.Cookies["userID"];
            var adminId = Int32.Parse(cookie.Value);

            DbModuls.DbAdd.addRoom(roomname, adminId, roompw);

            return RedirectToAction("Main", "Main");
        }

        public ActionResult JoinRoom()
        {
            int roomID = Int32.Parse(Request["joinroomID"]);
            string roompw = GetMd5Hash(Request["joinroompw"]);

            HttpCookie cookie = Request.Cookies["userID"];
            var userID = Int32.Parse(cookie.Value);

            if( DbModuls.DbAdd.requestJoinRoom( userID, roomID, roompw))
            {
                return RedirectToAction("Main", "Main");
            }
            else
            {
                ViewBag.Message = "ID is not exist or wrong password";
                return RedirectToAction("Main", "Main");
            }
            
        }

        [HttpPost]
        public ActionResult UpdateUserInfo( string updateName, string updatePassword, HttpPostedFileBase file )
        {
            HttpCookie cookie = Request.Cookies["userID"];
            var userID = Int32.Parse(cookie.Value);

            Models.User newUser = DbModuls.DbGet.getSpecificUser( userID );

            newUser.DisplayName = updateName;

            if( updatePassword != "")
            {
                newUser.Password_ = GetMd5Hash(updatePassword);
            }
            
            if( file != null)
            {
                //string filename = Path.GetFileNameWithoutExtension(file.FileName);
                //string extension = Path.GetExtension(file.FileName);

                //filename = filename + DateTime.Now.ToString() + extension;
                var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                string filepath = HttpContext.Server.MapPath("~/Content/img/avatars/") + Timestamp.ToString() + file.FileName;
                file.SaveAs( filepath );

                newUser.Avatar = "/Content/img/avatars/" + Timestamp.ToString() + file.FileName;
            }

            DbModuls.DbEdit.editUser(newUser);

            return RedirectToAction("Main", "Main");
        }
    }
}