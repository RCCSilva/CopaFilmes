import React, { useState } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import './App.css';
import ResultView from './views/ResultView';
import SelectionView from './views/SelectionView';


const App = () => {
  const [worldCup, setWorldCup] = useState(null);

  const createWoldCupHandler = (worldCup) => {
    setWorldCup(worldCup);
  }

  return (
    <div className='bg-gray-500 h-full px-16 pb-32'>
      <BrowserRouter>
        <Switch>
          <Route path='/result'>
            <ResultView
              worldCup={worldCup}/>
          </Route>
          <Route path='/'>
            <SelectionView
              createWoldCupHandler={createWoldCupHandler}/>
          </Route>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
