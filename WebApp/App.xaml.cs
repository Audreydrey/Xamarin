﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Plugin.LocalNotifications;
using SQLite;
using WebApp.Data;
using WebApp.Models;
using WebApp.Views;
using Xamarin.Forms;

namespace WebApp
{
    public partial class App : Application
    {
        public static UserDatabase Database;        //database of current user
        public static SQLiteAsyncConnection UserDB  //contains all IDs and index of database list that logged in before
        {
            get
            {
                string userDBPath = Path.Combine(Constants.PathPrefix, Constants.userDBFile);
                if (File.Exists(userDBPath))
                {
                    return new SQLiteAsyncConnection(userDBPath);
                }
                else
                {
                    SQLiteAsyncConnection connection = new SQLiteAsyncConnection(userDBPath);
                    connection.CreateTableAsync<UserDBModel>().Wait();
                    connection.InsertAsync(new UserDBModel(-1));
                    return connection;
                }

            }
        }
        public static SQLiteAsyncConnection UserLogDB
        {
            get
            {
                string logPath = Path.Combine(Constants.PathPrefix, Constants.LogFile);
                if (File.Exists(logPath))
                {
                    return new SQLiteAsyncConnection(logPath);
                }
                else
                {
                    SQLiteAsyncConnection connection = new SQLiteAsyncConnection(logPath);
                    connection.CreateTableAsync<UserLog>().Wait();
                    return connection;
                }
            }
        }

        public App()
        {
            InitializeComponent();
            Console.WriteLine(Constants.PathPrefix);
            string dbpth = Constants.PathPrefix;
            //if default user does not exist, go to login page
            int defaultUserIndex = GetDefaultUser();
            if (defaultUserIndex == Constants.DEFAULT_USER_NOT_EXIST)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {   //if default user exists, load default user
                string dbFile = string.Format("userDB{0}.db3", defaultUserIndex);
                String userPath = Path.Combine(Constants.PathPrefix, dbFile);
                App.Database = new UserDatabase(userPath);
                User.LoadFromLocal();
                Friend.LoadFromLocal();
                LoginPage login = new LoginPage();
                login.PushToMyTask();
                MainPage = new NavigationPage(login);
                Constants.firstLoginToday = UserLog.isFirstLoginToday();
                UserLog.WriteLoginTime();
            }
        }
        protected override void OnStart()
        {
            // On start runs when your application launches from a closed state, 
        }


        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Constants.firstLoginToday = UserLog.isFirstLoginToday();
            UserLog.WriteLoginTime();
        }

        //return default user database index
        private int GetDefaultUser()
        {
            SQLiteAsyncConnection db = UserDB;
            try
            {
                UserDBModel user = db.GetAsync<UserDBModel>(1).Result;
                int userid = user.userid;
                if (userid == -1)
                {
                    return Constants.DEFAULT_USER_NOT_EXIST;
                }
                string queryString = "SELECT * From UserDBModel WHERE userid = ?";
                var queryResult = UserDB.QueryAsync<UserDBModel>(queryString, user.userid).Result;
                int DBIndex = queryResult[1].DBIndex;
                return DBIndex;
            }
            catch (AggregateException)
            {
                return Constants.DEFAULT_USER_NOT_EXIST;
            }

        }
    }
}