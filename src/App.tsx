import { Logo } from "./components/Logo/Logo";
import { Form } from "./components/Input/Form";
import styles from "./App.module.css";
import "./global.css";
import { Tasks } from "./components/Tasks/Task";
import { useContext } from "react";
import { TodoContext } from "./Contexts/TodoContext";

export interface Task {
  id: number;
  name: string;
  isComplete: boolean;
}

const App = () => {
  const { tasks, newTask } = useContext(TodoContext);

  return (
    <div>
      <div className={styles.header}>
        <Logo />
        <Form taskValue={newTask} isButtonDisabled={!newTask.length} />
      </div>
      <Tasks tasks={tasks} />
    </div>
  );
};

export default App;
