﻿#pragma checksum "..\..\UserWalletRechargePrice_Win.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0017601DBFD02AA1722D315DF7A9C27AC1DB9B2AEDA6463789C6B824FC7D1D6F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AP_FinalProject_4002;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AP_FinalProject_4002 {
    
    
    /// <summary>
    /// UserWalletRechargePrice_Win
    /// </summary>
    public partial class UserWalletRechargePrice_Win : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\UserWalletRechargePrice_Win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserWalletRechargeTxtBx;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\UserWalletRechargePrice_Win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UserWalletRechargeCancelBtn;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\UserWalletRechargePrice_Win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UserRechargeBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AP_FinalProject_4002;component/userwalletrechargeprice_win.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserWalletRechargePrice_Win.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UserWalletRechargeTxtBx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.UserWalletRechargeCancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\UserWalletRechargePrice_Win.xaml"
            this.UserWalletRechargeCancelBtn.Click += new System.Windows.RoutedEventHandler(this.UserPayCancelBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.UserRechargeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\UserWalletRechargePrice_Win.xaml"
            this.UserRechargeBtn.Click += new System.Windows.RoutedEventHandler(this.UserRechargeBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

