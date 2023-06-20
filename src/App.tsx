import { Logo } from "./components/Logo/Logo";
import { Input } from "./components/Input/Input";
import Item from "./components/NoItem/NoItem";
import styles from "./App.module.css";

const App = () => {
  return (
    <div>
      <Logo />
      <Input />
      <div className={styles.tarefas}>
      <p className={styles.tarefa}>Tarefas criadas: 0</p>
      <p className={styles.tarefa}>Tarefas concluídas: 0</p>
      </div>
      <Item />
    </div>
  );
};

export default App;
