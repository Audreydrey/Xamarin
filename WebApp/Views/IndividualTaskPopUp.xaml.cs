﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using WebApp.Models;

namespace WebApp.Views
{
    public partial class IndividualTaskPopUp : Rg.Plugins.Popup.Pages.PopupPage
    {
        BaseTask task;
        bool isMyTask;
        public IndividualTaskPopUp(BaseTask task, bool isMyTask)
        {
            InitializeComponent();
            TaskName.Text = task.taskName;
            Progress.Text = task.getStatusString();
            Deadline.Text = task.getDeadlineString();
            TaskId.Text = task.taskID.ToString();
            this.task = task;
            foreach(int sup in task.related)
            {
                AddedFriends.Children.Add(Constants.Friend.GetViewof(sup));
            }
            this.isMyTask = isMyTask;
            if (!isMyTask)
            {
                sendingButton.IsVisible = false;
            }
            BindingContext = this;
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            int updateNo = await Communications.sendNewUpdate(task.taskID);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // ### Methods for supporting animations in your popup page ###

        // Invoked before an animation appearing
        protected override void OnAppearingAnimationBegin()
        {
            base.OnAppearingAnimationBegin();
        }

        // Invoked after an animation appearing
        protected override void OnAppearingAnimationEnd()
        {
            base.OnAppearingAnimationEnd();
        }

        // Invoked before an animation disappearing
        protected override void OnDisappearingAnimationBegin()
        {
            base.OnDisappearingAnimationBegin();
        }

        // Invoked after an animation disappearing
        protected override void OnDisappearingAnimationEnd()
        {
            base.OnDisappearingAnimationEnd();
        }

        protected override Task OnAppearingAnimationBeginAsync()
        {
            return base.OnAppearingAnimationBeginAsync();
        }

        protected override Task OnAppearingAnimationEndAsync()
        {
            return base.OnAppearingAnimationEndAsync();
        }

        protected override Task OnDisappearingAnimationBeginAsync()
        {
            return base.OnDisappearingAnimationBeginAsync();
        }

        protected override Task OnDisappearingAnimationEndAsync()
        {
            return base.OnDisappearingAnimationEndAsync();
        }

        // ### Overrided methods which can prevent closing a popup page ###

        // Invoked when a hardware back button is pressed
        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return base.OnBackButtonPressed();
        }

        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return base.OnBackgroundClicked();
        }
    }
}
