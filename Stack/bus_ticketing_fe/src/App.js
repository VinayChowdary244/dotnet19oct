import logo from './logo.svg';
import './App.css';
import AddBus from './Components/Addbus';
import RegisterUser from './Components/RegisterUser';
import GetBus from './Components/GetBusses';
import UserLogin from './Components/UserLogin';
import BusSeatSelection from './Components/BusSeatSelection';
import SearchBus from './Components/SearchBus';

function App() {
  return (
    <div className="App">
        {/*------------User Register and login--------------- <div className="row">
          <div className="col">
            <RegisterUser/> 
          </div>
          <div className="col">
            <UserLogin/>
          </div>
        </div> ---------------------------------------*/}



        {/* <div className="row">
          <div className="col">
            <BusSeatSelection/> 
          </div>
          <div className="col">
            
          </div>
        </div> */}

        
        <div className="row">
          <div className="col">
            <SearchBus/> 
          </div>
          <div className="col">
            
          </div>
        </div>





        {/*--------add and view busses----------- <div className="row">
          <div className="col">
            <GetBus/> 
          </div>
          <div className="col">
            <AddBus/>
          </div>
        </div> ------------------------------*/}















      {/* <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header> */}
    </div>
  );
}

export default App;
