﻿#pragma checksum "..\..\..\AdminManagerBookingResevationPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "239BCAC10A95C14F866E03041A9C225AFCF21DF6"
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
    /// AdminManagerBookingResevationPage
    /// </summary>
    public partial class AdminManagerBookingResevationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\AdminManagerBookingResevationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label userName;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\AdminManagerBookingResevationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock text_maxPrice;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\AdminManagerBookingResevationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_SearchName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\AdminManagerBookingResevationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock text_phone;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\AdminManagerBookingResevationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_phone;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\AdminManagerBookingResevationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_search;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\AdminManagerBookingResevationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListBookingResevation;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\AdminManagerBookingResevationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn RoomId;
        
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
            System.Uri resourceLocater = new System.Uri("/View;component/adminmanagerbookingresevationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminManagerBookingResevationPage.xaml"
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
            
            #line 11 "..\..\..\AdminManagerBookingResevationPage.xaml"
            ((View.AdminManagerBookingResevationPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.userName = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.text_maxPrice = ((System.Windows.Controls.TextBlock)(target));
            
            #line 29 "..\..\..\AdminManagerBookingResevationPage.xaml"
            this.text_maxPrice.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.text_maxPrice_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_SearchName = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\AdminManagerBookingResevationPage.xaml"
            this.txt_SearchName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_SearchName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.text_phone = ((System.Windows.Controls.TextBlock)(target));
            
            #line 40 "..\..\..\AdminManagerBookingResevationPage.xaml"
            this.text_phone.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.text_phone_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txt_phone = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\..\AdminManagerBookingResevationPage.xaml"
            this.txt_phone.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_phone_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_search = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\AdminManagerBookingResevationPage.xaml"
            this.btn_search.Click += new System.Windows.RoutedEventHandler(this.btn_search_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 53 "..\..\..\AdminManagerBookingResevationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ListBookingResevation = ((System.Windows.Controls.ListView)(target));
            
            #line 66 "..\..\..\AdminManagerBookingResevationPage.xaml"
            this.ListBookingResevation.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListRoomtype_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.RoomId = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 11:
            
            #line 100 "..\..\..\AdminManagerBookingResevationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 110 "..\..\..\AdminManagerBookingResevationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
