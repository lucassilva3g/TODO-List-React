import { Input } from "./components/Input";
import { Logo } from "./components/Logo";
import Items from "./components/Items";

import "./styles/index.css";

const App = () => {
  return (
    <div>
      <Logo />
      <Input />
     <div className="tarefas">
     <p className="tarefa">Tarefas criadas: 0</p>
        <p className="tarefa">Tarefas concluídas: 0</p>
     </div>
      <Items />
    </div>
  );
};

export default App;
