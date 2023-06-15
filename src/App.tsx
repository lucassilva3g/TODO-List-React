import {Logo} from './components/Logo';
import { InputBut } from './components/input';
import './styles/index.css';


const App = () => {
  return (
    <div>
      { <Logo /> }
      { <InputBut /> }

    </div>
  );
};

export default App;
