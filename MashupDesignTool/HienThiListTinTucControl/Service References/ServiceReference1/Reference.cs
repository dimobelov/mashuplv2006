﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 4.0.50401.0
// 
namespace HienThiListTinTucControl.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetStringFromURL", ReplyAction="http://tempuri.org/IService1/GetStringFromURLResponse")]
        System.IAsyncResult BeginGetStringFromURL(string url, System.AsyncCallback callback, object asyncState);
        
        string EndGetStringFromURL(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetDataFromURL", ReplyAction="http://tempuri.org/IService1/GetDataFromURLResponse")]
        System.IAsyncResult BeginGetDataFromURL(string url, System.AsyncCallback callback, object asyncState);
        
        byte[] EndGetDataFromURL(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : HienThiListTinTucControl.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetStringFromURLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetStringFromURLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetDataFromURLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetDataFromURLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public byte[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<HienThiListTinTucControl.ServiceReference1.IService1>, HienThiListTinTucControl.ServiceReference1.IService1 {
        
        private BeginOperationDelegate onBeginGetStringFromURLDelegate;
        
        private EndOperationDelegate onEndGetStringFromURLDelegate;
        
        private System.Threading.SendOrPostCallback onGetStringFromURLCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetDataFromURLDelegate;
        
        private EndOperationDelegate onEndGetDataFromURLDelegate;
        
        private System.Threading.SendOrPostCallback onGetDataFromURLCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<GetStringFromURLCompletedEventArgs> GetStringFromURLCompleted;
        
        public event System.EventHandler<GetDataFromURLCompletedEventArgs> GetDataFromURLCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult HienThiListTinTucControl.ServiceReference1.IService1.BeginGetStringFromURL(string url, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetStringFromURL(url, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string HienThiListTinTucControl.ServiceReference1.IService1.EndGetStringFromURL(System.IAsyncResult result) {
            return base.Channel.EndGetStringFromURL(result);
        }
        
        private System.IAsyncResult OnBeginGetStringFromURL(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string url = ((string)(inValues[0]));
            return ((HienThiListTinTucControl.ServiceReference1.IService1)(this)).BeginGetStringFromURL(url, callback, asyncState);
        }
        
        private object[] OnEndGetStringFromURL(System.IAsyncResult result) {
            string retVal = ((HienThiListTinTucControl.ServiceReference1.IService1)(this)).EndGetStringFromURL(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetStringFromURLCompleted(object state) {
            if ((this.GetStringFromURLCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetStringFromURLCompleted(this, new GetStringFromURLCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetStringFromURLAsync(string url) {
            this.GetStringFromURLAsync(url, null);
        }
        
        public void GetStringFromURLAsync(string url, object userState) {
            if ((this.onBeginGetStringFromURLDelegate == null)) {
                this.onBeginGetStringFromURLDelegate = new BeginOperationDelegate(this.OnBeginGetStringFromURL);
            }
            if ((this.onEndGetStringFromURLDelegate == null)) {
                this.onEndGetStringFromURLDelegate = new EndOperationDelegate(this.OnEndGetStringFromURL);
            }
            if ((this.onGetStringFromURLCompletedDelegate == null)) {
                this.onGetStringFromURLCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetStringFromURLCompleted);
            }
            base.InvokeAsync(this.onBeginGetStringFromURLDelegate, new object[] {
                        url}, this.onEndGetStringFromURLDelegate, this.onGetStringFromURLCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult HienThiListTinTucControl.ServiceReference1.IService1.BeginGetDataFromURL(string url, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetDataFromURL(url, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        byte[] HienThiListTinTucControl.ServiceReference1.IService1.EndGetDataFromURL(System.IAsyncResult result) {
            return base.Channel.EndGetDataFromURL(result);
        }
        
        private System.IAsyncResult OnBeginGetDataFromURL(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string url = ((string)(inValues[0]));
            return ((HienThiListTinTucControl.ServiceReference1.IService1)(this)).BeginGetDataFromURL(url, callback, asyncState);
        }
        
        private object[] OnEndGetDataFromURL(System.IAsyncResult result) {
            byte[] retVal = ((HienThiListTinTucControl.ServiceReference1.IService1)(this)).EndGetDataFromURL(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetDataFromURLCompleted(object state) {
            if ((this.GetDataFromURLCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetDataFromURLCompleted(this, new GetDataFromURLCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetDataFromURLAsync(string url) {
            this.GetDataFromURLAsync(url, null);
        }
        
        public void GetDataFromURLAsync(string url, object userState) {
            if ((this.onBeginGetDataFromURLDelegate == null)) {
                this.onBeginGetDataFromURLDelegate = new BeginOperationDelegate(this.OnBeginGetDataFromURL);
            }
            if ((this.onEndGetDataFromURLDelegate == null)) {
                this.onEndGetDataFromURLDelegate = new EndOperationDelegate(this.OnEndGetDataFromURL);
            }
            if ((this.onGetDataFromURLCompletedDelegate == null)) {
                this.onGetDataFromURLCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetDataFromURLCompleted);
            }
            base.InvokeAsync(this.onBeginGetDataFromURLDelegate, new object[] {
                        url}, this.onEndGetDataFromURLDelegate, this.onGetDataFromURLCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override HienThiListTinTucControl.ServiceReference1.IService1 CreateChannel() {
            return new Service1ClientChannel(this);
        }
        
        private class Service1ClientChannel : ChannelBase<HienThiListTinTucControl.ServiceReference1.IService1>, HienThiListTinTucControl.ServiceReference1.IService1 {
            
            public Service1ClientChannel(System.ServiceModel.ClientBase<HienThiListTinTucControl.ServiceReference1.IService1> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetStringFromURL(string url, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = url;
                System.IAsyncResult _result = base.BeginInvoke("GetStringFromURL", _args, callback, asyncState);
                return _result;
            }
            
            public string EndGetStringFromURL(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("GetStringFromURL", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetDataFromURL(string url, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = url;
                System.IAsyncResult _result = base.BeginInvoke("GetDataFromURL", _args, callback, asyncState);
                return _result;
            }
            
            public byte[] EndGetDataFromURL(System.IAsyncResult result) {
                object[] _args = new object[0];
                byte[] _result = ((byte[])(base.EndInvoke("GetDataFromURL", _args, result)));
                return _result;
            }
        }
    }
}
