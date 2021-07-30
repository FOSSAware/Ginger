﻿using amdocs.ginger.GingerCoreNET;
using Amdocs.Ginger.Common.SelfHealingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ginger.Run
{
    /// <summary>
    /// Interaction logic for GingerSelfHealingConfiguration.xaml
    /// </summary>
    public partial class GingerSelfHealingConfiguration : Page
    {
        GenericWindow genWin = null;
        RunSetConfig mRunSetConfig;

        public GingerSelfHealingConfiguration()
        {
            InitializeComponent();

            GingerCore.GeneralLib.BindingHandler.ObjFieldBinding(xEnableSelfHealingChkBox, CheckBox.IsCheckedProperty, WorkSpace.Instance.AutomateTabSelfHealingConfiguration, nameof(SelfHealingConfig.EnableSelfHealing));
            GingerCore.GeneralLib.BindingHandler.ObjFieldBinding(xAutoFixAnalyzerChkBox, CheckBox.IsCheckedProperty, WorkSpace.Instance.AutomateTabSelfHealingConfiguration, nameof(SelfHealingConfig.AutoFixAnalyzerIssue));
            GingerCore.GeneralLib.BindingHandler.ObjFieldBinding(xRePrioritizeChkBox, CheckBox.IsCheckedProperty, WorkSpace.Instance.AutomateTabSelfHealingConfiguration, nameof(SelfHealingConfig.PrioritizePOMLocator));
            GingerCore.GeneralLib.BindingHandler.ObjFieldBinding(xAutoUpdateModelChkBox, CheckBox.IsCheckedProperty, WorkSpace.Instance.AutomateTabSelfHealingConfiguration, nameof(SelfHealingConfig.AutoUpdateApplicationModel));

            ShowHideConfigPanel();
        }

        public GingerSelfHealingConfiguration(RunSetConfig runSetConfig)
        {
            InitializeComponent();
            mRunSetConfig = runSetConfig;

            GingerCore.GeneralLib.BindingHandler.ObjFieldBinding(xEnableSelfHealingChkBox, CheckBox.IsCheckedProperty, mRunSetConfig.SelfHealingConfiguration, nameof(SelfHealingConfig.EnableSelfHealing));
            GingerCore.GeneralLib.BindingHandler.ObjFieldBinding(xAutoFixAnalyzerChkBox, CheckBox.IsCheckedProperty, mRunSetConfig.SelfHealingConfiguration, nameof(SelfHealingConfig.AutoFixAnalyzerIssue));
            GingerCore.GeneralLib.BindingHandler.ObjFieldBinding(xRePrioritizeChkBox, CheckBox.IsCheckedProperty, mRunSetConfig.SelfHealingConfiguration, nameof(SelfHealingConfig.PrioritizePOMLocator));
            GingerCore.GeneralLib.BindingHandler.ObjFieldBinding(xAutoUpdateModelChkBox, CheckBox.IsCheckedProperty, mRunSetConfig.SelfHealingConfiguration, nameof(SelfHealingConfig.AutoUpdateApplicationModel));

            ShowHideConfigPanel();
        }

        public void ShowAsWindow()
        {
            this.Width = 350;
            this.Height = 350;
            GingerCore.General.LoadGenericWindow(ref genWin, App.MainWindow, Ginger.eWindowShowStyle.Dialog, this.Title, this);
        }

        private void xEnableSelfHealingChkBox_Click(object sender, RoutedEventArgs e)
        {
            ShowHideConfigPanel();
        }

        private void ShowHideConfigPanel()
        {
            if (xEnableSelfHealingChkBox.IsChecked == true)
            {
                xSelfHealingConfigPanel.Visibility = Visibility.Visible;
            }
            else
            {
                xSelfHealingConfigPanel.Visibility = Visibility.Collapsed;
                mRunSetConfig.SelfHealingConfiguration.AutoFixAnalyzerIssue = false;
                mRunSetConfig.SelfHealingConfiguration.PrioritizePOMLocator = false;
                mRunSetConfig.SelfHealingConfiguration.AutoUpdateApplicationModel = false;
                mRunSetConfig.SelfHealingConfiguration.SaveChangesInSourceControl = false;
            }
        }
    }
}
