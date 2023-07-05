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

const tasksDone = tasks.filter((task) => task.isComplete).length;

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setNewTask(event.target.value);
  };

  const handleDelete = (taskId: number) => {
    setTasks(tasks.filter((taskItem) => taskItem.id !== taskId));
  };

  const handleDone = (taskId: number) => {
    setTasks((prevTasks) =>
      prevTasks.map((task) =>
        task.id === taskId ? { ...task, isComplete: !task.isComplete } : task
      )
    );
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
      <Logo />
      <Input
        onCreatNewTask={handleCreateNewTask}
        onInputChange={handleInputChange}
        taskValue={newTask}
        isButtonDisabled={!newTask.length}
      />

      <div className={styles.tarefas}>
        <p className={styles.tarefa}>Tarefas criadas: {tasks.length}</p>
        <p className={styles.tarefa}>Tarefas concluídas: {tasksDone} de {tasks.length} </p>
      </div>

      {tasks.length === 0 ? (
        <NoItem />
      ) : (
        <div>
          {tasks.map((task) => (
            <Item
              key={task.id}
              done={task.isComplete}
              todo={task.name}
              onDelete={() => handleDelete(task.id)}
              onDone={() => handleDone(task.id)}
            />
          ))}
        </div>
      )}
    </div>
  );
};

export default App;
