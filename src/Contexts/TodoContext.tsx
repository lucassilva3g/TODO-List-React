import React, { createContext, useState, useEffect } from "react";
import { ReactNode } from "react";
import { Task } from "../App";

interface TodoContextProps {
  tasks: Task[];
  addTask: (newTask: Task) => void;
  toggleTaskCompletion: (taskId: number) => void;
  handleInputChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
  handleCreateNewTask: () => void;
  newTask: string;
  handleDone: (taskId: number) => void;
  handleDelete: (taskId: number) => void;
}

interface TodoProviderProps {
  children: ReactNode;
}

export const TodoContext = createContext<TodoContextProps>({
  tasks: [],
  addTask: () => {},
  toggleTaskCompletion: () => {},
  handleInputChange: () => {},
  handleCreateNewTask: () => {},
  newTask: "",
  handleDone: () => {},
  handleDelete: () => {},
});

export const TodoProvider: React.FC<TodoProviderProps> = ({ children }) => {
  const [tasks, setTasks] = useState<Task[]>(() => {
    const storageTasks = localStorage.getItem("@TodoApp:tasks");
    if (storageTasks) {
      console.log(JSON.parse(storageTasks));
      return JSON.parse(storageTasks);
    }
    return [];
  });

  useEffect(() => {
    localStorage.setItem("@TodoApp:tasks", JSON.stringify(tasks));
  }, [tasks]);


  const [newTask, setNewTask] = useState("");

  const addTask = (newTask: Task) => {
    setTasks((oldTasks) => [...oldTasks, newTask]);
  };

  const toggleTaskCompletion = (taskId: number) => {
    const updatedTasks = tasks.map((task) => {
      if (task.id === taskId) {
        return { ...task, isComplete: !task.isComplete };
      }
      return task;
    });
    setTasks(updatedTasks);
  };

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setNewTask(event.target.value);
  };

  const handleCreateNewTask = () => {
    const task: Task = {
      id: Math.random(),
      name: newTask,
      isComplete: false,
    };
    const newTasks = [...tasks, task];
    setTasks(newTasks);
    setNewTask("");
  };

  const handleDone = (taskId: number) => {
    setTasks((prevTasks) =>
      prevTasks.map((task) =>
        task.id === taskId ? { ...task, isComplete: !task.isComplete } : task
      )
    );
  };

  const handleDelete = (taskId: number) => {
    setTasks(tasks.filter((taskItem) => taskItem.id !== taskId));
  };

  return (
    <TodoContext.Provider
      value={{
        tasks,
        addTask,
        toggleTaskCompletion,
        handleInputChange,
        handleCreateNewTask,
        newTask,
        handleDone,
        handleDelete,
      }}
    >
      {children}
    </TodoContext.Provider>
  );
};
