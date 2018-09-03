﻿namespace EveAIO.Views
{
    using EveAIO;
    using EveAIO.Notifications;
    using EveAIO.Pocos;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Data;
    using System.Windows.Markup;

    public class NotificationsView : UserControl, IComponentConnector
    {
        internal TabControl tbControl;
        internal TabItem tabTwitter;
        internal ToggleButton switchTwitter;
        public DataGrid gvTwitter;
        internal Button btnTestTwitter;
        internal TabItem tabSlack;
        internal ToggleButton switchSlack;
        public DataGrid gvSlack;
        internal Button btnTestSlack;
        internal TabItem tabSms;
        internal ToggleButton switchSms;
        public DataGrid gvSms;
        internal Button btnTestSms;
        internal TabItem tabDiscord;
        internal ToggleButton switchDiscord;
        public DataGrid gvDiscord;
        internal Button btnTestDiscord;
        private bool _contentLoaded;

        public NotificationsView()
        {
            Class7.RIuqtBYzWxthF();
            this.InitializeComponent();
            ICollectionView defaultView = CollectionViewSource.GetDefaultView(Global.SETTINGS.TWITTER);
            this.gvTwitter.ItemsSource = defaultView;
            this.gvTwitter.IsEnabled = false;
            this.gvTwitter.Opacity = 0.9;
            this.switchTwitter.IsChecked = new bool?(Global.SETTINGS.TwitterOn);
            ICollectionView view2 = CollectionViewSource.GetDefaultView(Global.SETTINGS.SLACK);
            this.gvSlack.ItemsSource = view2;
            this.gvSlack.IsEnabled = false;
            this.gvSlack.Opacity = 0.9;
            this.switchSlack.IsChecked = new bool?(Global.SETTINGS.SlackOn);
            ICollectionView view3 = CollectionViewSource.GetDefaultView(Global.SETTINGS.SMS);
            this.gvSms.ItemsSource = view3;
            this.gvSms.IsEnabled = false;
            this.gvSms.Opacity = 0.9;
            this.switchSms.IsChecked = new bool?(Global.SETTINGS.SmsOn);
            ICollectionView view4 = CollectionViewSource.GetDefaultView(Global.SETTINGS.DISCORD);
            this.gvDiscord.ItemsSource = view4;
            this.gvDiscord.IsEnabled = false;
            this.gvDiscord.Opacity = 0.9;
            this.switchDiscord.IsChecked = new bool?(Global.SETTINGS.DiscordOn);
            this.tbControl.SelectedIndex = 0;
        }

        private void btnTestDiscord_Click(object sender, RoutedEventArgs e)
        {
            if ((this.gvDiscord.SelectedItems.Count == 1) && (this.gvDiscord.SelectedItem is DiscordObject))
            {
                DiscordObject selectedItem = this.gvDiscord.SelectedItem as DiscordObject;
                new Notificator().Discord(Notificator.NotificationType.Restock, selectedItem);
            }
        }

        private void btnTestSlack_Click(object sender, RoutedEventArgs e)
        {
            if ((this.gvSlack.SelectedItems.Count == 1) && (this.gvSlack.SelectedItem is SlackObject))
            {
                SlackObject selectedItem = this.gvSlack.SelectedItem as SlackObject;
                new Notificator().Slack(Notificator.NotificationType.Restock, selectedItem);
            }
        }

        private void btnTestSms_Click(object sender, RoutedEventArgs e)
        {
            if ((this.gvSms.SelectedItems.Count == 1) && (this.gvSms.SelectedItem is SmsObject))
            {
                SmsObject selectedItem = this.gvSms.SelectedItem as SmsObject;
                new Notificator().Twilio(Notificator.NotificationType.Restock, selectedItem);
            }
        }

        private void btnTestTwitter_Click(object sender, RoutedEventArgs e)
        {
            if ((this.gvTwitter.SelectedItems.Count == 1) && (this.gvTwitter.SelectedItem is TwitterObject))
            {
                TwitterObject selectedItem = this.gvTwitter.SelectedItem as TwitterObject;
                new Notificator().Tweet(Notificator.NotificationType.Restock, selectedItem);
            }
        }

        private void gvDiscord_AutoGeneratedColumns(object sender, EventArgs e)
        {
            foreach (DataGridColumn column in this.gvDiscord.Columns)
            {
                if (column.Header.ToString() == "DiscordType")
                {
                    DataGridComboBoxColumn column2 = column as DataGridComboBoxColumn;
                    if (column2 != null)
                    {
                        column2.Header = "TYPE";
                        column2.Width = 90.0;
                        column2.MinWidth = 90.0;
                        column2.CanUserResize = false;
                        column2.HeaderStyle = this.gvDiscord.FindResource("column0") as Style;
                        column2.CellStyle = this.gvDiscord.FindResource("cellColumn0") as Style;
                    }
                }
                else if (column.Header.ToString() == "WebhookId")
                {
                    DataGridTextColumn column5 = column as DataGridTextColumn;
                    if (column5 != null)
                    {
                        column5.Header = "WEBHOOK ID";
                        column5.Width = 220.0;
                        column5.MinWidth = 50.0;
                        column5.HeaderStyle = this.gvDiscord.FindResource("column0") as Style;
                        column5.CellStyle = this.gvDiscord.FindResource("cellColumn1") as Style;
                        column5.ElementStyle = this.gvDiscord.FindResource("txtStyle") as Style;
                        column5.EditingElementStyle = this.gvDiscord.FindResource("TextBoxGrid") as Style;
                    }
                }
                else if (column.Header.ToString() == "WebhookToken")
                {
                    DataGridTextColumn column4 = column as DataGridTextColumn;
                    if (column4 != null)
                    {
                        column4.Header = "WEBHOOK TOKEN";
                        column4.Width = 145.0;
                        column4.MinWidth = 50.0;
                        column4.HeaderStyle = this.gvDiscord.FindResource("column0") as Style;
                        column4.CellStyle = this.gvDiscord.FindResource("cellColumn2") as Style;
                        column4.ElementStyle = this.gvDiscord.FindResource("txtStyle") as Style;
                        column4.EditingElementStyle = this.gvDiscord.FindResource("TextBoxGrid") as Style;
                    }
                }
                else if (column.Header.ToString() == "Message")
                {
                    DataGridTextColumn column3 = column as DataGridTextColumn;
                    if (column3 != null)
                    {
                        column3.Header = "MESSAGE";
                        column3.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
                        column3.MinWidth = 50.0;
                        column3.FontSize = 14.0;
                        column3.HeaderStyle = this.gvDiscord.FindResource("column2") as Style;
                        column3.CellStyle = this.gvDiscord.FindResource("cellColumn6") as Style;
                        column3.ElementStyle = this.gvDiscord.FindResource("txtStyle") as Style;
                        column3.EditingElementStyle = this.gvDiscord.FindResource("TextBoxGrid") as Style;
                    }
                }
            }
        }

        private void gvDiscord_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
        }

        private void gvDiscord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((this.gvDiscord.SelectedItems.Count == 1) && (this.gvDiscord.SelectedItem is DiscordObject))
            {
                this.btnTestDiscord.IsEnabled = true;
                this.btnTestDiscord.Opacity = 1.0;
            }
            else
            {
                this.btnTestDiscord.IsEnabled = false;
                this.btnTestDiscord.Opacity = 0.6;
            }
        }

        private void gvSlack_AutoGeneratedColumns(object sender, EventArgs e)
        {
            foreach (DataGridColumn column2 in this.gvSlack.Columns)
            {
                if (column2.Header.ToString() != "SlackType")
                {
                    if (column2.Header.ToString() == "Hook")
                    {
                        DataGridTextColumn column6 = column2 as DataGridTextColumn;
                        if (column6 != null)
                        {
                            column6.Header = "HOOK";
                            column6.Width = 220.0;
                            column6.MinWidth = 50.0;
                            column6.HeaderStyle = this.gvSlack.FindResource("column0") as Style;
                            column6.CellStyle = this.gvSlack.FindResource("cellColumn1") as Style;
                            column6.ElementStyle = this.gvSlack.FindResource("txtStyle") as Style;
                            column6.EditingElementStyle = this.gvSlack.FindResource("TextBoxGrid") as Style;
                        }
                    }
                    else if (column2.Header.ToString() != "Username")
                    {
                        if (column2.Header.ToString() == "Channel")
                        {
                            DataGridTextColumn column4 = column2 as DataGridTextColumn;
                            if (column4 != null)
                            {
                                column4.Header = "CHANNEL";
                                column4.Width = 145.0;
                                column4.MinWidth = 50.0;
                                column4.HeaderStyle = this.gvSlack.FindResource("column0") as Style;
                                column4.CellStyle = this.gvSlack.FindResource("cellColumn3") as Style;
                                column4.ElementStyle = this.gvSlack.FindResource("txtStyle") as Style;
                                column4.EditingElementStyle = this.gvSlack.FindResource("TextBoxGrid") as Style;
                            }
                        }
                        else if (column2.Header.ToString() == "Message")
                        {
                            DataGridTextColumn column3 = column2 as DataGridTextColumn;
                            if (column3 != null)
                            {
                                column3.Header = "MESSAGE";
                                column3.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
                                column3.MinWidth = 50.0;
                                column3.FontSize = 14.0;
                                column3.HeaderStyle = this.gvSlack.FindResource("column2") as Style;
                                column3.CellStyle = this.gvSlack.FindResource("cellColumn6") as Style;
                                column3.ElementStyle = this.gvSlack.FindResource("txtStyle") as Style;
                                column3.EditingElementStyle = this.gvSlack.FindResource("TextBoxGrid") as Style;
                            }
                        }
                    }
                    else
                    {
                        DataGridTextColumn column5 = column2 as DataGridTextColumn;
                        if (column5 != null)
                        {
                            column5.Header = "USERNAME";
                            column5.Width = 145.0;
                            column5.MinWidth = 50.0;
                            column5.HeaderStyle = this.gvSlack.FindResource("column0") as Style;
                            column5.CellStyle = this.gvSlack.FindResource("cellColumn2") as Style;
                            column5.ElementStyle = this.gvSlack.FindResource("txtStyle") as Style;
                            column5.EditingElementStyle = this.gvSlack.FindResource("TextBoxGrid") as Style;
                        }
                    }
                }
                else
                {
                    DataGridComboBoxColumn column = column2 as DataGridComboBoxColumn;
                    if (column != null)
                    {
                        column.Header = "TYPE";
                        column.Width = 90.0;
                        column.MinWidth = 90.0;
                        column.CanUserResize = false;
                        column.HeaderStyle = this.gvSlack.FindResource("column0") as Style;
                        column.CellStyle = this.gvSlack.FindResource("cellColumn0") as Style;
                    }
                }
            }
        }

        private void gvSlack_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
        }

        private void gvSlack_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((this.gvSlack.SelectedItems.Count == 1) && (this.gvSlack.SelectedItem is SlackObject))
            {
                this.btnTestSlack.IsEnabled = true;
                this.btnTestSlack.Opacity = 1.0;
            }
            else
            {
                this.btnTestSlack.IsEnabled = false;
                this.btnTestSlack.Opacity = 0.6;
            }
        }

        private void gvSms_AutoGeneratedColumns(object sender, EventArgs e)
        {
            foreach (DataGridColumn column3 in this.gvSms.Columns)
            {
                if (column3.Header.ToString() != "SmsType")
                {
                    if (column3.Header.ToString() == "AccountSid")
                    {
                        DataGridTextColumn column6 = column3 as DataGridTextColumn;
                        if (column6 != null)
                        {
                            column6.Header = "ACCOUNT SID";
                            column6.Width = 220.0;
                            column6.MinWidth = 50.0;
                            column6.HeaderStyle = this.gvSms.FindResource("column0") as Style;
                            column6.CellStyle = this.gvSms.FindResource("cellColumn1") as Style;
                            column6.ElementStyle = this.gvSms.FindResource("txtStyle") as Style;
                            column6.EditingElementStyle = this.gvSms.FindResource("TextBoxGrid") as Style;
                        }
                    }
                    else if (column3.Header.ToString() == "AuthToken")
                    {
                        DataGridTextColumn column7 = column3 as DataGridTextColumn;
                        if (column7 != null)
                        {
                            column7.Header = "TOKEN";
                            column7.Width = 145.0;
                            column7.MinWidth = 50.0;
                            column7.HeaderStyle = this.gvSms.FindResource("column0") as Style;
                            column7.CellStyle = this.gvSms.FindResource("cellColumn2") as Style;
                            column7.ElementStyle = this.gvSms.FindResource("txtStyle") as Style;
                            column7.EditingElementStyle = this.gvSms.FindResource("TextBoxGrid") as Style;
                        }
                    }
                    else if (column3.Header.ToString() != "NumberFrom")
                    {
                        if (column3.Header.ToString() != "NumberTo")
                        {
                            if (column3.Header.ToString() == "Message")
                            {
                                DataGridTextColumn column = column3 as DataGridTextColumn;
                                if (column != null)
                                {
                                    column.Header = "MESSAGE";
                                    column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
                                    column.MinWidth = 50.0;
                                    column.FontSize = 14.0;
                                    column.HeaderStyle = this.gvSms.FindResource("column2") as Style;
                                    column.CellStyle = this.gvSms.FindResource("cellColumn6") as Style;
                                    column.ElementStyle = this.gvSms.FindResource("txtStyle") as Style;
                                    column.EditingElementStyle = this.gvSms.FindResource("TextBoxGrid") as Style;
                                }
                            }
                        }
                        else
                        {
                            DataGridTextColumn column4 = column3 as DataGridTextColumn;
                            if (column4 != null)
                            {
                                column4.Header = "NUMBER TO";
                                column4.Width = 145.0;
                                column4.MinWidth = 50.0;
                                column4.HeaderStyle = this.gvSms.FindResource("column0") as Style;
                                column4.CellStyle = this.gvSms.FindResource("cellColumn4") as Style;
                                column4.ElementStyle = this.gvSms.FindResource("txtStyle") as Style;
                                column4.EditingElementStyle = this.gvSms.FindResource("TextBoxGrid") as Style;
                            }
                        }
                    }
                    else
                    {
                        DataGridTextColumn column2 = column3 as DataGridTextColumn;
                        if (column2 != null)
                        {
                            column2.Header = "NUMBER FROM";
                            column2.Width = 145.0;
                            column2.MinWidth = 50.0;
                            column2.HeaderStyle = this.gvSms.FindResource("column0") as Style;
                            column2.CellStyle = this.gvSms.FindResource("cellColumn3") as Style;
                            column2.ElementStyle = this.gvSms.FindResource("txtStyle") as Style;
                            column2.EditingElementStyle = this.gvSms.FindResource("TextBoxGrid") as Style;
                        }
                    }
                }
                else
                {
                    DataGridComboBoxColumn column5 = column3 as DataGridComboBoxColumn;
                    if (column5 != null)
                    {
                        column5.Header = "TYPE";
                        column5.Width = 90.0;
                        column5.MinWidth = 90.0;
                        column5.CanUserResize = false;
                        column5.HeaderStyle = this.gvSms.FindResource("column0") as Style;
                        column5.CellStyle = this.gvSms.FindResource("cellColumn0") as Style;
                    }
                }
            }
        }

        private void gvSms_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
        }

        private void gvSms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((this.gvSms.SelectedItems.Count == 1) && (this.gvSms.SelectedItem is SmsObject))
            {
                this.btnTestSms.IsEnabled = true;
                this.btnTestSms.Opacity = 1.0;
            }
            else
            {
                this.btnTestSms.IsEnabled = false;
                this.btnTestSms.Opacity = 0.6;
            }
        }

        private void gvTwitter_AutoGeneratedColumns(object sender, EventArgs e)
        {
            foreach (DataGridColumn column2 in this.gvTwitter.Columns)
            {
                if (column2.Header.ToString() != "TwitterType")
                {
                    if (column2.Header.ToString() != "ConsumerKey")
                    {
                        if (column2.Header.ToString() != "ConsumerKeySecret")
                        {
                            if (column2.Header.ToString() == "AccessToken")
                            {
                                DataGridTextColumn column7 = column2 as DataGridTextColumn;
                                if (column7 != null)
                                {
                                    column7.Header = "ACCESS TOKEN";
                                    column7.Width = 165.0;
                                    column7.MinWidth = 50.0;
                                    column7.HeaderStyle = this.gvTwitter.FindResource("column0") as Style;
                                    column7.CellStyle = this.gvTwitter.FindResource("cellColumn3") as Style;
                                    column7.ElementStyle = this.gvTwitter.FindResource("txtStyle") as Style;
                                    column7.EditingElementStyle = this.gvTwitter.FindResource("TextBoxGrid") as Style;
                                }
                            }
                            else if (column2.Header.ToString() == "AccessTokenSecret")
                            {
                                DataGridTextColumn column4 = column2 as DataGridTextColumn;
                                if (column4 != null)
                                {
                                    column4.Header = "ACCESS TOKEN SECRET";
                                    column4.Width = 160.0;
                                    column4.MinWidth = 50.0;
                                    column4.HeaderStyle = this.gvTwitter.FindResource("column0") as Style;
                                    column4.CellStyle = this.gvTwitter.FindResource("cellColumn4") as Style;
                                    column4.ElementStyle = this.gvTwitter.FindResource("txtStyle") as Style;
                                    column4.EditingElementStyle = this.gvTwitter.FindResource("TextBoxGrid") as Style;
                                }
                            }
                            else if (column2.Header.ToString() == "Message")
                            {
                                DataGridTextColumn column3 = column2 as DataGridTextColumn;
                                if (column3 != null)
                                {
                                    column3.Header = "MESSAGE";
                                    column3.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
                                    column3.MinWidth = 50.0;
                                    column3.FontSize = 14.0;
                                    column3.HeaderStyle = this.gvTwitter.FindResource("column2") as Style;
                                    column3.CellStyle = this.gvTwitter.FindResource("cellColumn6") as Style;
                                    column3.ElementStyle = this.gvTwitter.FindResource("txtStyle") as Style;
                                    column3.EditingElementStyle = this.gvTwitter.FindResource("TextBoxGrid") as Style;
                                }
                            }
                        }
                        else
                        {
                            DataGridTextColumn column6 = column2 as DataGridTextColumn;
                            if (column6 != null)
                            {
                                column6.Header = "CONSUMER KEY SECRET";
                                column6.Width = 165.0;
                                column6.MinWidth = 50.0;
                                column6.HeaderStyle = this.gvTwitter.FindResource("column0") as Style;
                                column6.CellStyle = this.gvTwitter.FindResource("cellColumn2") as Style;
                                column6.ElementStyle = this.gvTwitter.FindResource("txtStyle") as Style;
                                column6.EditingElementStyle = this.gvTwitter.FindResource("TextBoxGrid") as Style;
                            }
                        }
                    }
                    else
                    {
                        DataGridTextColumn column = column2 as DataGridTextColumn;
                        if (column != null)
                        {
                            column.Header = "CONSUMER KEY";
                            column.Width = 145.0;
                            column.MinWidth = 50.0;
                            column.HeaderStyle = this.gvTwitter.FindResource("column0") as Style;
                            column.CellStyle = this.gvTwitter.FindResource("cellColumn1") as Style;
                            column.ElementStyle = this.gvTwitter.FindResource("txtStyle") as Style;
                            column.EditingElementStyle = this.gvTwitter.FindResource("TextBoxGrid") as Style;
                        }
                    }
                }
                else
                {
                    DataGridComboBoxColumn column5 = column2 as DataGridComboBoxColumn;
                    if (column5 != null)
                    {
                        column5.Header = "TYPE";
                        column5.Width = 90.0;
                        column5.MinWidth = 90.0;
                        column5.CanUserResize = false;
                        column5.HeaderStyle = this.gvTwitter.FindResource("column0") as Style;
                        column5.CellStyle = this.gvTwitter.FindResource("cellColumn0") as Style;
                    }
                }
            }
        }

        private void gvTwitter_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
        }

        private void gvTwitter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((this.gvTwitter.SelectedItems.Count == 1) && (this.gvTwitter.SelectedItem is TwitterObject))
            {
                this.btnTestTwitter.IsEnabled = true;
                this.btnTestTwitter.Opacity = 1.0;
            }
            else
            {
                this.btnTestTwitter.IsEnabled = false;
                this.btnTestTwitter.Opacity = 0.6;
            }
        }

        [GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Uri resourceLocator = new Uri("/EveAIO;component/views/notificationsview.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
            }
        }

        private void switchDiscord_Checked(object sender, RoutedEventArgs e)
        {
            this.tbControl.SelectedItem = this.tabDiscord;
            if (this.switchDiscord.IsChecked.HasValue && this.switchDiscord.IsChecked.Value)
            {
                Global.SETTINGS.DiscordOn = true;
                this.gvDiscord.IsEnabled = true;
                this.gvDiscord.Opacity = 1.0;
            }
            else
            {
                Global.SETTINGS.DiscordOn = false;
                this.gvDiscord.IsEnabled = false;
                this.gvDiscord.Opacity = 0.9;
                this.btnTestDiscord.IsEnabled = false;
                this.btnTestDiscord.Opacity = 0.6;
            }
            Helpers.SaveSettings();
        }

        private void switchSlack_Checked(object sender, RoutedEventArgs e)
        {
            this.tbControl.SelectedItem = this.tabSlack;
            if (this.switchSlack.IsChecked.HasValue && this.switchSlack.IsChecked.Value)
            {
                Global.SETTINGS.SlackOn = true;
                this.gvSlack.IsEnabled = true;
                this.gvSlack.Opacity = 1.0;
            }
            else
            {
                Global.SETTINGS.SlackOn = false;
                this.gvSlack.IsEnabled = false;
                this.gvSlack.Opacity = 0.9;
                this.btnTestSlack.IsEnabled = false;
                this.btnTestSlack.Opacity = 0.6;
            }
            Helpers.SaveSettings();
        }

        private void switchSms_Checked(object sender, RoutedEventArgs e)
        {
            this.tbControl.SelectedItem = this.tabSms;
            if (this.switchSms.IsChecked.HasValue && this.switchSms.IsChecked.Value)
            {
                Global.SETTINGS.SmsOn = true;
                this.gvSms.IsEnabled = true;
                this.gvSms.Opacity = 1.0;
            }
            else
            {
                Global.SETTINGS.SmsOn = false;
                this.gvSms.IsEnabled = false;
                this.gvSms.Opacity = 0.9;
                this.btnTestSms.IsEnabled = false;
                this.btnTestSms.Opacity = 0.6;
            }
            Helpers.SaveSettings();
        }

        private void switchTwitter_Checked(object sender, RoutedEventArgs e)
        {
            this.tbControl.SelectedItem = this.tabTwitter;
            if (this.switchTwitter.IsChecked.HasValue && this.switchTwitter.IsChecked.Value)
            {
                Global.SETTINGS.TwitterOn = true;
                this.gvTwitter.IsEnabled = true;
                this.gvTwitter.Opacity = 1.0;
            }
            else
            {
                Global.SETTINGS.TwitterOn = false;
                this.gvTwitter.IsEnabled = false;
                this.gvTwitter.Opacity = 0.9;
                this.btnTestTwitter.IsEnabled = false;
                this.btnTestTwitter.Opacity = 0.6;
            }
            Helpers.SaveSettings();
        }

        [GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        void IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.tbControl = (TabControl) target;
                    return;

                case 2:
                    this.tabTwitter = (TabItem) target;
                    return;

                case 3:
                    this.switchTwitter = (ToggleButton) target;
                    this.switchTwitter.Checked += new RoutedEventHandler(this.switchTwitter_Checked);
                    this.switchTwitter.Unchecked += new RoutedEventHandler(this.switchTwitter_Checked);
                    return;

                case 4:
                    this.gvTwitter = (DataGrid) target;
                    this.gvTwitter.SelectionChanged += new SelectionChangedEventHandler(this.gvTwitter_SelectionChanged);
                    this.gvTwitter.AutoGeneratingColumn += new EventHandler<DataGridAutoGeneratingColumnEventArgs>(this.gvTwitter_AutoGeneratingColumn);
                    this.gvTwitter.AutoGeneratedColumns += new EventHandler(this.gvTwitter_AutoGeneratedColumns);
                    return;

                case 5:
                    this.btnTestTwitter = (Button) target;
                    this.btnTestTwitter.Click += new RoutedEventHandler(this.btnTestTwitter_Click);
                    return;

                case 6:
                    this.tabSlack = (TabItem) target;
                    return;

                case 7:
                    this.switchSlack = (ToggleButton) target;
                    this.switchSlack.Checked += new RoutedEventHandler(this.switchSlack_Checked);
                    this.switchSlack.Unchecked += new RoutedEventHandler(this.switchSlack_Checked);
                    return;

                case 8:
                    this.gvSlack = (DataGrid) target;
                    this.gvSlack.SelectionChanged += new SelectionChangedEventHandler(this.gvSlack_SelectionChanged);
                    this.gvSlack.AutoGeneratingColumn += new EventHandler<DataGridAutoGeneratingColumnEventArgs>(this.gvSlack_AutoGeneratingColumn);
                    this.gvSlack.AutoGeneratedColumns += new EventHandler(this.gvSlack_AutoGeneratedColumns);
                    return;

                case 9:
                    this.btnTestSlack = (Button) target;
                    this.btnTestSlack.Click += new RoutedEventHandler(this.btnTestSlack_Click);
                    return;

                case 10:
                    this.tabSms = (TabItem) target;
                    return;

                case 11:
                    this.switchSms = (ToggleButton) target;
                    this.switchSms.Checked += new RoutedEventHandler(this.switchSms_Checked);
                    this.switchSms.Unchecked += new RoutedEventHandler(this.switchSms_Checked);
                    return;

                case 12:
                    this.gvSms = (DataGrid) target;
                    this.gvSms.SelectionChanged += new SelectionChangedEventHandler(this.gvSms_SelectionChanged);
                    this.gvSms.AutoGeneratingColumn += new EventHandler<DataGridAutoGeneratingColumnEventArgs>(this.gvSms_AutoGeneratingColumn);
                    this.gvSms.AutoGeneratedColumns += new EventHandler(this.gvSms_AutoGeneratedColumns);
                    return;

                case 13:
                    this.btnTestSms = (Button) target;
                    this.btnTestSms.Click += new RoutedEventHandler(this.btnTestSms_Click);
                    return;

                case 14:
                    this.tabDiscord = (TabItem) target;
                    return;

                case 15:
                    this.switchDiscord = (ToggleButton) target;
                    this.switchDiscord.Checked += new RoutedEventHandler(this.switchDiscord_Checked);
                    this.switchDiscord.Unchecked += new RoutedEventHandler(this.switchDiscord_Checked);
                    return;

                case 0x10:
                    this.gvDiscord = (DataGrid) target;
                    this.gvDiscord.SelectionChanged += new SelectionChangedEventHandler(this.gvDiscord_SelectionChanged);
                    this.gvDiscord.AutoGeneratingColumn += new EventHandler<DataGridAutoGeneratingColumnEventArgs>(this.gvDiscord_AutoGeneratingColumn);
                    this.gvDiscord.AutoGeneratedColumns += new EventHandler(this.gvDiscord_AutoGeneratedColumns);
                    return;

                case 0x11:
                    this.btnTestDiscord = (Button) target;
                    this.btnTestDiscord.Click += new RoutedEventHandler(this.btnTestDiscord_Click);
                    return;
            }
            this._contentLoaded = true;
        }
    }
}
