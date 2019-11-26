import React from 'react';
import {Route, Link, BrowserRouter as Router, Switch} from 'react-router-dom';
import ReactDOM from 'react-dom';
import './index.css';
import App from './pages/Home/App';
import * as serviceWorker from './serviceWorker';
import Login from './pages/Login/Login';


const routing = (
    <Router>
        <div>
            <Switch>
                {/* passa o componente que vai se renderizado */}
                <Route exact path='/' component={App} />
                <Route path='/login' component={Login}/>
                {/* <Route path='/cadastrar' component={Cadastro}/>
                <Route path='/lancamentos' component={Lancamentos}/>
                <Route component={NaoEncontrado}/> */}
            </Switch>
        </div>
    </Router>
)

ReactDOM.render(<App />, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
