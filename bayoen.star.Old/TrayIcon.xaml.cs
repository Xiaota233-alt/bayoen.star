﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Hardcodet.Wpf.TaskbarNotification;

namespace bayoen.star
{
    public partial class TrayIcon : TaskbarIcon
    {
        public TrayIcon()
        {
            this.InitializeComponent();
            this.Icon = bayoen.star.Properties.Resources.StarCarbyPlusIcon;
            this.ToolTipText = Config.AssemblyTitle;
            this.MenuActivation = PopupActivationMode.LeftOrRightClick;
            this.MenuHeader.Header = $"{Config.AssemblyTitle} v{Config.Version}";
            this.ContextMenu.PlacementTarget = Core.MainWindow;

            //this.TrayPopupResolved.VerticalOffset = 100;
            //this.TrayPopupResolved.HorizontalAlignment = HorizontalAlignment.Right;
            //this.TrayPopupResolved.PopupAnimation = PopupAnimation.Fade;
            //this.TrayPopupResolved.StaysOpen = true;
            //this.TrayPopupResolved.IsOpen = true;


#if DEBUG
            this.MenuHeader.Header = $"{Config.AssemblyTitle} v{Config.VersionString}";
            MenuItem DebugMenuItem = new MenuItem();
            DebugMenuItem.SetResourceReference(MenuItem.HeaderProperty, "Debug-Tray-Debug-String");

            MenuItem DebugShowMenuItem = new MenuItem();
            DebugShowMenuItem.SetResourceReference(MenuItem.HeaderProperty, "Debug-Tray-Debug-Show-String");
            DebugShowMenuItem.Click += (sender, e) => Core.DebugWindow.Show();
            DebugMenuItem.Items.Add(DebugShowMenuItem);

            MenuItem DebugFolderMenuItem = new MenuItem();
            DebugFolderMenuItem.SetResourceReference(MenuItem.HeaderProperty, "Debug-Tray-Debug-Folder-String");
            DebugFolderMenuItem.Click += (sender, e) => Core.ShowFolder();
            DebugMenuItem.Items.Add(DebugFolderMenuItem);

            this.ContextMenu.Items.Insert(4, DebugMenuItem);
#endif
        }

        public void Terminate()
        {
            this.Visibility = Visibility.Collapsed;
            this.Dispose();
        }

        private void TaskbarIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e) => Core.MainWindow.Show();

        private void ShowMenuItem_Click(object sender, RoutedEventArgs e) => Core.MainWindow.Show();

        private void SettingMenuItem_Click(object sender, RoutedEventArgs e) => Core.SettingWindow.Show();

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e) => Core.Terminate();
    }
}
