﻿using Airsqreen.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airsqreen.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public void ConnectionString()
        {
            con.ConnectionString = "data source=DESKTOP-J6J2EQI\\SQLEXPRESS01; database=Airsqreen; integrated security = SSPI;";
        }

        public ActionResult Verify(Account acc)
        {
            ConnectionString();
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "select * from accounts where username='" + acc.Username + "' and password='" + acc.Password + "'";

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return View();
            }
        }
    }
}