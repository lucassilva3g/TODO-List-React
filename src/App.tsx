import { Logo } from "./components/Logo/Logo";
import { Input } from "./components/Input/Input";
import Item from "./components/Item/Item";
import styles from "./App.module.css";

const App = () => {
  return (
    <div>
      <Logo />
      <Input />
      <div className={styles.tarefas}>
        <p className="tarefa">Tarefas criadas: 0</p>
        <p className="tarefa">Tarefas concluídas: 0</p>
      </div>
      <Item />
    </div>
  );
};

export default App;
