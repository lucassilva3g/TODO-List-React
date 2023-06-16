import {PlusCircle} from "@phosphor-icons/react";

const Input = () => {
  return (
    <div className="elem">
      <input type="text" placeholder="Adicione uma nova tarefa" />
      <button>Criar <PlusCircle size={11} /> </button>
    </div>
  );
};


export {Input};
