import { Logo } from "./components/Logo/Logo";
import { Form } from "./components/Input/Form";
import styles from "./App.module.css";
import "./global.css";
import { useState } from "react";
import { Tasks } from "./components/Tasks/Task";

export interface Task {
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
    setTasks(newTasks);
    setNewTask("");
  };

  return (
    <div>
      <div className={styles.header}>
        <Logo />
        <Form
          onCreatNewTask={handleCreateNewTask}
          onInputChange={handleInputChange}
          taskValue={newTask}
          isButtonDisabled={!newTask.length}
        />
      </div>
      <Tasks tasks={tasks} setTasks={setTasks} />


    </div>
  );
};

export default App;
