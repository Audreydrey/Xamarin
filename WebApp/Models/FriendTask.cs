﻿using System;
using Xamarin.Forms;

namespace WebApp.Models
{
    public class FriendTask
    {
        internal int taskid;
        internal string taskname;
        internal bool completed;
        internal string ownername;
        private Frame view;
        TapGestureRecognizer tapRecog;
        private BaseTask task;
        public FriendTask(BaseTask task)
        {
            this.task = task;
            this.taskid = task.taskID;
            //substring
            this.taskname = task.taskName;
            this.ownername = Constants.Friend.getNameOf(task.ownerid);
            completed = false;
            tapRecog = new TapGestureRecognizer();
            tapRecog.Tapped += (sender, e) => { Constants.mainPage.FriendTaskDetail(task); };
        }

        public Frame GetView()
        {
            if(view == null)
            {
                Frame taskCard = new Frame
                {
                    CornerRadius = 10,
                    Padding = 10,
                    BackgroundColor = Color.Gray,
                    HeightRequest = 60,
                    Margin = 20,
                    HorizontalOptions = LayoutOptions.Center,
                    WidthRequest = 330,
                    Content = getContentGrid()
                };
                taskCard.GestureRecognizers.Add(tapRecog);
                view = taskCard;
            }
            return view;
        }

        internal virtual Grid getContentGrid()
        {
            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = 200},
                    new ColumnDefinition {Width = 130}
                },
                RowDefinitions =
                {
                    new RowDefinition {Height = 20},
                    new RowDefinition {Height = 40}
                }
            };
            grid.Children.Add(new Label
            {
                Text = ownername,
                FontSize = 15,
                TextColor = Color.White
            }, 0, 0);

            grid.Children.Add(new Label
            {
                Text = taskname,
                FontSize = 30,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start
            }, 0, 1);
            return grid;
        }

    }
}
