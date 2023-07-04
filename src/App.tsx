import { Logo } from "./components/Logo/Logo";
import { Input } from "./components/Input/Input";
import { NoItem } from "./components/NoItem/NoItem";
import styles from "./App.module.css";
import { useState } from "react";
import { Item } from "./components/Item/Item";

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


  const handleDelete = (taskId: number) => {
    setTasks(tasks.filter((taskItem) => taskItem.id !== taskId));
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
         isButtonDisabled={!newTask.length}
       />

      <div className={styles.tarefas}>
        <p className={styles.tarefa}>Tarefas criadas: {tasks.length}</p>
        <p className={styles.tarefa}>Tarefas concluídas: 0</p>
      </div>

      {tasks.length === 0 ? (
        <NoItem />
      ) : (
        <div>
          {tasks.map((task) => (
            <Item
              done={task.isComplete}
              todo={task.name}
              onDelete={() =>
                handleDelete(task.id)
              }
            />
          ))}
        </div>
      )}
    </div>
  );
};

export default App;
