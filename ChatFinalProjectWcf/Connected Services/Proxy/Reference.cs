﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatFinalProjectWcf.Proxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cell", Namespace="http://schemas.datacontract.org/2004/07/Models.Cell")]
    [System.SerializableAttribute()]
    public partial class Cell : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SoldierAmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ChatFinalProjectWcf.Proxy.Color colorField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SoldierAmount {
            get {
                return this.SoldierAmountField;
            }
            set {
                if ((this.SoldierAmountField.Equals(value) != true)) {
                    this.SoldierAmountField = value;
                    this.RaisePropertyChanged("SoldierAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ChatFinalProjectWcf.Proxy.Color color {
            get {
                return this.colorField;
            }
            set {
                if ((this.colorField.Equals(value) != true)) {
                    this.colorField = value;
                    this.RaisePropertyChanged("color");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Color", Namespace="http://schemas.datacontract.org/2004/07/Models.Cell")]
    public enum Color : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Red = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Black = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        empty = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MessageCommon", Namespace="http://schemas.datacontract.org/2004/07/Common.common")]
    [System.SerializableAttribute()]
    public partial class MessageCommon : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] listOfMessagesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] listOfMessages {
            get {
                return this.listOfMessagesField;
            }
            set {
                if ((object.ReferenceEquals(this.listOfMessagesField, value) != true)) {
                    this.listOfMessagesField = value;
                    this.RaisePropertyChanged("listOfMessages");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserCommon", Namespace="http://schemas.datacontract.org/2004/07/Common.common")]
    [System.SerializableAttribute()]
    public partial class UserCommon : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] listOfUserField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] listOfUser {
            get {
                return this.listOfUserField;
            }
            set {
                if ((object.ReferenceEquals(this.listOfUserField, value) != true)) {
                    this.listOfUserField = value;
                    this.RaisePropertyChanged("listOfUser");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GameCommon", Namespace="http://schemas.datacontract.org/2004/07/Common.common")]
    [System.SerializableAttribute()]
    public partial class GameCommon : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ChatFinalProjectWcf.Proxy.Cell[] CellsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int[] DiceNumsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] DiceNumsImgField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageForPlayerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TurnOfField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ChatFinalProjectWcf.Proxy.Cell[] Cells {
            get {
                return this.CellsField;
            }
            set {
                if ((object.ReferenceEquals(this.CellsField, value) != true)) {
                    this.CellsField = value;
                    this.RaisePropertyChanged("Cells");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] DiceNums {
            get {
                return this.DiceNumsField;
            }
            set {
                if ((object.ReferenceEquals(this.DiceNumsField, value) != true)) {
                    this.DiceNumsField = value;
                    this.RaisePropertyChanged("DiceNums");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] DiceNumsImg {
            get {
                return this.DiceNumsImgField;
            }
            set {
                if ((object.ReferenceEquals(this.DiceNumsImgField, value) != true)) {
                    this.DiceNumsImgField = value;
                    this.RaisePropertyChanged("DiceNumsImg");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MessageForPlayer {
            get {
                return this.MessageForPlayerField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageForPlayerField, value) != true)) {
                    this.MessageForPlayerField = value;
                    this.RaisePropertyChanged("MessageForPlayer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TurnOf {
            get {
                return this.TurnOfField;
            }
            set {
                if ((object.ReferenceEquals(this.TurnOfField, value) != true)) {
                    this.TurnOfField = value;
                    this.RaisePropertyChanged("TurnOf");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxy.IChatContract", CallbackContract=typeof(ChatFinalProjectWcf.Proxy.IChatContractCallback))]
    public interface IChatContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Register", ReplyAction="http://tempuri.org/IChatContract/RegisterResponse")]
        string Register(string userName, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Register", ReplyAction="http://tempuri.org/IChatContract/RegisterResponse")]
        System.Threading.Tasks.Task<string> RegisterAsync(string userName, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Login", ReplyAction="http://tempuri.org/IChatContract/LoginResponse")]
        string Login(string UserName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Login", ReplyAction="http://tempuri.org/IChatContract/LoginResponse")]
        System.Threading.Tasks.Task<string> LoginAsync(string UserName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Logout", ReplyAction="http://tempuri.org/IChatContract/LogoutResponse")]
        void Logout(string UserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Logout", ReplyAction="http://tempuri.org/IChatContract/LogoutResponse")]
        System.Threading.Tasks.Task LogoutAsync(string UserName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/SendMessage")]
        void SendMessage(string m, string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(string m, string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/GameRequest")]
        void GameRequest(string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/GameRequest")]
        System.Threading.Tasks.Task GameRequestAsync(string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/StartGame")]
        void StartGame(string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/StartGame")]
        System.Threading.Tasks.Task StartGameAsync(string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/ChatRequest")]
        void ChatRequest(string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/ChatRequest")]
        System.Threading.Tasks.Task ChatRequestAsync(string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/StartChat")]
        void StartChat(string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/StartChat")]
        System.Threading.Tasks.Task StartChatAsync(string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/GetGameBoard", ReplyAction="http://tempuri.org/IChatContract/GetGameBoardResponse")]
        ChatFinalProjectWcf.Proxy.Cell[] GetGameBoard();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/GetGameBoard", ReplyAction="http://tempuri.org/IChatContract/GetGameBoardResponse")]
        System.Threading.Tasks.Task<ChatFinalProjectWcf.Proxy.Cell[]> GetGameBoardAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/NewGame", ReplyAction="http://tempuri.org/IChatContract/NewGameResponse")]
        ChatFinalProjectWcf.Proxy.Cell[] NewGame(string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/NewGame", ReplyAction="http://tempuri.org/IChatContract/NewGameResponse")]
        System.Threading.Tasks.Task<ChatFinalProjectWcf.Proxy.Cell[]> NewGameAsync(string sender, string reciever);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Roll", ReplyAction="http://tempuri.org/IChatContract/RollResponse")]
        bool Roll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Roll", ReplyAction="http://tempuri.org/IChatContract/RollResponse")]
        System.Threading.Tasks.Task<bool> RollAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/CheckFinish", ReplyAction="http://tempuri.org/IChatContract/CheckFinishResponse")]
        void CheckFinish();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/CheckFinish", ReplyAction="http://tempuri.org/IChatContract/CheckFinishResponse")]
        System.Threading.Tasks.Task CheckFinishAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Eat", ReplyAction="http://tempuri.org/IChatContract/EatResponse")]
        void Eat();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Eat", ReplyAction="http://tempuri.org/IChatContract/EatResponse")]
        System.Threading.Tasks.Task EatAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/OutOfEat", ReplyAction="http://tempuri.org/IChatContract/OutOfEatResponse")]
        bool OutOfEat(int current, int dicenum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/OutOfEat", ReplyAction="http://tempuri.org/IChatContract/OutOfEatResponse")]
        System.Threading.Tasks.Task<bool> OutOfEatAsync(int current, int dicenum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/CheckIfEaten", ReplyAction="http://tempuri.org/IChatContract/CheckIfEatenResponse")]
        bool CheckIfEaten();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/CheckIfEaten", ReplyAction="http://tempuri.org/IChatContract/CheckIfEatenResponse")]
        System.Threading.Tasks.Task<bool> CheckIfEatenAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/CheckWinner", ReplyAction="http://tempuri.org/IChatContract/CheckWinnerResponse")]
        bool CheckWinner();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/CheckWinner", ReplyAction="http://tempuri.org/IChatContract/CheckWinnerResponse")]
        System.Threading.Tasks.Task<bool> CheckWinnerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/UpdateGameBoard", ReplyAction="http://tempuri.org/IChatContract/UpdateGameBoardResponse")]
        void UpdateGameBoard(int current, int target, ChatFinalProjectWcf.Proxy.Color color);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/UpdateGameBoard", ReplyAction="http://tempuri.org/IChatContract/UpdateGameBoardResponse")]
        System.Threading.Tasks.Task UpdateGameBoardAsync(int current, int target, ChatFinalProjectWcf.Proxy.Color color);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Move", ReplyAction="http://tempuri.org/IChatContract/MoveResponse")]
        bool Move(int current, int dicenum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/Move", ReplyAction="http://tempuri.org/IChatContract/MoveResponse")]
        System.Threading.Tasks.Task<bool> MoveAsync(int current, int dicenum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/EndTurn", ReplyAction="http://tempuri.org/IChatContract/EndTurnResponse")]
        void EndTurn();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/EndTurn", ReplyAction="http://tempuri.org/IChatContract/EndTurnResponse")]
        System.Threading.Tasks.Task EndTurnAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/GetAvailableMoves", ReplyAction="http://tempuri.org/IChatContract/GetAvailableMovesResponse")]
        int GetAvailableMoves();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/GetAvailableMoves", ReplyAction="http://tempuri.org/IChatContract/GetAvailableMovesResponse")]
        System.Threading.Tasks.Task<int> GetAvailableMovesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/CheckIfFinishTurn", ReplyAction="http://tempuri.org/IChatContract/CheckIfFinishTurnResponse")]
        bool CheckIfFinishTurn();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/CheckIfFinishTurn", ReplyAction="http://tempuri.org/IChatContract/CheckIfFinishTurnResponse")]
        System.Threading.Tasks.Task<bool> CheckIfFinishTurnAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/UserColor", ReplyAction="http://tempuri.org/IChatContract/UserColorResponse")]
        string UserColor();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/UserColor", ReplyAction="http://tempuri.org/IChatContract/UserColorResponse")]
        System.Threading.Tasks.Task<string> UserColorAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/FinishGame", ReplyAction="http://tempuri.org/IChatContract/FinishGameResponse")]
        void FinishGame();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatContract/FinishGame", ReplyAction="http://tempuri.org/IChatContract/FinishGameResponse")]
        System.Threading.Tasks.Task FinishGameAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatContractCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/IncomingMessage")]
        void IncomingMessage(ChatFinalProjectWcf.Proxy.MessageCommon mc);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/IncomingUserConnected")]
        void IncomingUserConnected(ChatFinalProjectWcf.Proxy.UserCommon uc);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/IncomingGame")]
        void IncomingGame(string user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/IncomingChatScreen")]
        void IncomingChatScreen(string user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/IncomingChatRequest")]
        void IncomingChatRequest(string sender);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/IncomingGameRequest")]
        void IncomingGameRequest(string sender);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/IncomingDiceNums")]
        void IncomingDiceNums(ChatFinalProjectWcf.Proxy.GameCommon gc);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/GetBoardGame")]
        void GetBoardGame(ChatFinalProjectWcf.Proxy.GameCommon gc);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/IncomingWinner")]
        void IncomingWinner(string sender);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/IncomingTurn")]
        void IncomingTurn(ChatFinalProjectWcf.Proxy.GameCommon gc);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatContract/IncomingMessageForPlayer")]
        void IncomingMessageForPlayer(ChatFinalProjectWcf.Proxy.GameCommon gc);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatContractChannel : ChatFinalProjectWcf.Proxy.IChatContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatContractClient : System.ServiceModel.DuplexClientBase<ChatFinalProjectWcf.Proxy.IChatContract>, ChatFinalProjectWcf.Proxy.IChatContract {
        
        public ChatContractClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatContractClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public string Register(string userName, string Password) {
            return base.Channel.Register(userName, Password);
        }
        
        public System.Threading.Tasks.Task<string> RegisterAsync(string userName, string Password) {
            return base.Channel.RegisterAsync(userName, Password);
        }
        
        public string Login(string UserName, string password) {
            return base.Channel.Login(UserName, password);
        }
        
        public System.Threading.Tasks.Task<string> LoginAsync(string UserName, string password) {
            return base.Channel.LoginAsync(UserName, password);
        }
        
        public void Logout(string UserName) {
            base.Channel.Logout(UserName);
        }
        
        public System.Threading.Tasks.Task LogoutAsync(string UserName) {
            return base.Channel.LogoutAsync(UserName);
        }
        
        public void SendMessage(string m, string sender, string reciever) {
            base.Channel.SendMessage(m, sender, reciever);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(string m, string sender, string reciever) {
            return base.Channel.SendMessageAsync(m, sender, reciever);
        }
        
        public void GameRequest(string sender, string reciever) {
            base.Channel.GameRequest(sender, reciever);
        }
        
        public System.Threading.Tasks.Task GameRequestAsync(string sender, string reciever) {
            return base.Channel.GameRequestAsync(sender, reciever);
        }
        
        public void StartGame(string sender, string reciever) {
            base.Channel.StartGame(sender, reciever);
        }
        
        public System.Threading.Tasks.Task StartGameAsync(string sender, string reciever) {
            return base.Channel.StartGameAsync(sender, reciever);
        }
        
        public void ChatRequest(string sender, string reciever) {
            base.Channel.ChatRequest(sender, reciever);
        }
        
        public System.Threading.Tasks.Task ChatRequestAsync(string sender, string reciever) {
            return base.Channel.ChatRequestAsync(sender, reciever);
        }
        
        public void StartChat(string sender, string reciever) {
            base.Channel.StartChat(sender, reciever);
        }
        
        public System.Threading.Tasks.Task StartChatAsync(string sender, string reciever) {
            return base.Channel.StartChatAsync(sender, reciever);
        }
        
        public ChatFinalProjectWcf.Proxy.Cell[] GetGameBoard() {
            return base.Channel.GetGameBoard();
        }
        
        public System.Threading.Tasks.Task<ChatFinalProjectWcf.Proxy.Cell[]> GetGameBoardAsync() {
            return base.Channel.GetGameBoardAsync();
        }
        
        public ChatFinalProjectWcf.Proxy.Cell[] NewGame(string sender, string reciever) {
            return base.Channel.NewGame(sender, reciever);
        }
        
        public System.Threading.Tasks.Task<ChatFinalProjectWcf.Proxy.Cell[]> NewGameAsync(string sender, string reciever) {
            return base.Channel.NewGameAsync(sender, reciever);
        }
        
        public bool Roll() {
            return base.Channel.Roll();
        }
        
        public System.Threading.Tasks.Task<bool> RollAsync() {
            return base.Channel.RollAsync();
        }
        
        public void CheckFinish() {
            base.Channel.CheckFinish();
        }
        
        public System.Threading.Tasks.Task CheckFinishAsync() {
            return base.Channel.CheckFinishAsync();
        }
        
        public void Eat() {
            base.Channel.Eat();
        }
        
        public System.Threading.Tasks.Task EatAsync() {
            return base.Channel.EatAsync();
        }
        
        public bool OutOfEat(int current, int dicenum) {
            return base.Channel.OutOfEat(current, dicenum);
        }
        
        public System.Threading.Tasks.Task<bool> OutOfEatAsync(int current, int dicenum) {
            return base.Channel.OutOfEatAsync(current, dicenum);
        }
        
        public bool CheckIfEaten() {
            return base.Channel.CheckIfEaten();
        }
        
        public System.Threading.Tasks.Task<bool> CheckIfEatenAsync() {
            return base.Channel.CheckIfEatenAsync();
        }
        
        public bool CheckWinner() {
            return base.Channel.CheckWinner();
        }
        
        public System.Threading.Tasks.Task<bool> CheckWinnerAsync() {
            return base.Channel.CheckWinnerAsync();
        }
        
        public void UpdateGameBoard(int current, int target, ChatFinalProjectWcf.Proxy.Color color) {
            base.Channel.UpdateGameBoard(current, target, color);
        }
        
        public System.Threading.Tasks.Task UpdateGameBoardAsync(int current, int target, ChatFinalProjectWcf.Proxy.Color color) {
            return base.Channel.UpdateGameBoardAsync(current, target, color);
        }
        
        public bool Move(int current, int dicenum) {
            return base.Channel.Move(current, dicenum);
        }
        
        public System.Threading.Tasks.Task<bool> MoveAsync(int current, int dicenum) {
            return base.Channel.MoveAsync(current, dicenum);
        }
        
        public void EndTurn() {
            base.Channel.EndTurn();
        }
        
        public System.Threading.Tasks.Task EndTurnAsync() {
            return base.Channel.EndTurnAsync();
        }
        
        public int GetAvailableMoves() {
            return base.Channel.GetAvailableMoves();
        }
        
        public System.Threading.Tasks.Task<int> GetAvailableMovesAsync() {
            return base.Channel.GetAvailableMovesAsync();
        }
        
        public bool CheckIfFinishTurn() {
            return base.Channel.CheckIfFinishTurn();
        }
        
        public System.Threading.Tasks.Task<bool> CheckIfFinishTurnAsync() {
            return base.Channel.CheckIfFinishTurnAsync();
        }
        
        public string UserColor() {
            return base.Channel.UserColor();
        }
        
        public System.Threading.Tasks.Task<string> UserColorAsync() {
            return base.Channel.UserColorAsync();
        }
        
        public void FinishGame() {
            base.Channel.FinishGame();
        }
        
        public System.Threading.Tasks.Task FinishGameAsync() {
            return base.Channel.FinishGameAsync();
        }
    }
}