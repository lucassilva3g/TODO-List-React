import { Logo } from "./components/Logo/Logo";
import { Input } from "./components/Input/Input";
import { NoItem } from "./components/NoItem/NoItem";
import styles from "./App.module.css";
import { useState } from "react";
import {Item} from "./components/Item/Item";

interface Task {
  id: number;
  name: string;
  isComplete: boolean;
}

const App = () => {
  const [newTask, setNewTask] = useState("");
  const [tasks, setTasks] = useState<Task[]>([]);
  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setNewTask(event.target.value);
  };

  const handleCreateNewTask = () => {
    const task = {
      id: Math.random(),
      name: newTask,
      isComplete: false,
    };
    const newTasks = [...tasks, task];
    console.log(newTasks);
    setTasks(newTasks);
    setNewTask("");
  };
  return (
    <div>
      <Logo />
      <Input
        onCreatNewTask={handleCreateNewTask}
        onInputChange={handleInputChange}
        taskValue={newTask}
      />
      <div className={styles.tarefas}>
        <p className={styles.tarefa}>Tarefas criadas: 0</p>
        <p className={styles.tarefa}>Tarefas concluídas: 0</p>
      </div>
      {/* <NoItem /> */}
      {tasks.length === 0 ? (
        <NoItem />
      ) : (
        <div>
          {tasks.map((task) => (
            <Item
            done={task.isComplete}
            todo={task.name}
            onDelete={() => console.log("deletar")}
            />

          ))}
          </div>
      )}
    </div>

  );
};

export default App;
