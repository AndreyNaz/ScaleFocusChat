import React, { Component } from 'react';
import { ChatWindow } from './components/ChatWindow'
import { AddRoomForm } from './components/AddRoomForm'
import { RoomList } from './components/RoomList'
import { SendMessageForm } from './components/SendMessageForm'
import { UserList } from './components/UserList'
import './App.css';

class App extends Component {
  render() {
    return (
        <div className="App">
            <ChatWindow />
            <AddRoomForm />
            <RoomList />
            <SendMessageForm />
            <UserList />
      </div>
    );
  }
}

export default App;
