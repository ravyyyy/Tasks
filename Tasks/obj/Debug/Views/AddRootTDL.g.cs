﻿#pragma checksum "..\..\..\Views\AddRootTDL.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5EC42AC915A55C664539B9D01D5BBF69C68C9658A76636BAD7DEC5079C007169"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Tasks.Views;


namespace Tasks.Views {
    
    
    /// <summary>
    /// AddRootTDL
    /// </summary>
    public partial class AddRootTDL : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Views\AddRootTDL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Views\AddRootTDL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageSlide;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Views\AddRootTDL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button leftButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Views\AddRootTDL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button rightButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Views\AddRootTDL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirmButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Tasks;component/views/addroottdl.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AddRootTDL.xaml"
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
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.imageSlide = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.leftButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Views\AddRootTDL.xaml"
            this.leftButton.Click += new System.Windows.RoutedEventHandler(this.LeftButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rightButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Views\AddRootTDL.xaml"
            this.rightButton.Click += new System.Windows.RoutedEventHandler(this.RightButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.confirmButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Views\AddRootTDL.xaml"
            this.confirmButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
