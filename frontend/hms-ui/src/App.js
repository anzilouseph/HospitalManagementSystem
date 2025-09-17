import logo from './logo.svg';
import './App.css';
import { BrowserRouter } from 'react-router-dom'; 
import RouteFile from './Routes/routeFile';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <BrowserRouter>
            <RouteFile/>
        </BrowserRouter>
      </header>
    </div>
  );
}

export default App;
