﻿#pragma checksum "..\..\..\AddRoomPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CBAF66D84B5953B72C87075E62C3F4184A4D1220"
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
using System.Windows.Controls.Ribbon;
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
using View;


namespace View {
    
    
    /// <summary>
    /// AddRoomPage
    /// </summary>
    public partial class AddRoomPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\AddRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_roomNumber;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\AddRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_RoomMaxCapacity;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AddRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_RoomDetailDescription;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\AddRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_pricePerDay;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\AddRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox txt_roomStatus;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\AddRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox listRoomType;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\AddRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_AddRoom;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\AddRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/View;component/addroompage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddRoomPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\AddRoomPage.xaml"
            ((View.AddRoomPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_roomNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_RoomMaxCapacity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_RoomDetailDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_pricePerDay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txt_roomStatus = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.listRoomType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\AddRoomPage.xaml"
            this.listRoomType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.combobox_fillter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_AddRoom = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\AddRoomPage.xaml"
            this.btn_AddRoom.Click += new System.Windows.RoutedEventHandler(this.btn_AddRoom_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_back = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\AddRoomPage.xaml"
            this.btn_back.Click += new System.Windows.RoutedEventHandler(this.btn_back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
