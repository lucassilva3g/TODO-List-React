import {Clipboard} from "@phosphor-icons/react";

const items = () => {
  if (items.length === 0) {
    return (
      <div className="itens-lista">
        <p><Clipboard size={40} /></p>
        <p>Você ainda não tem tarefas cadastradas</p>
        <p>Crie tarefas e organize seus itens a fazer</p>
      </div>
    );
  }

  return <div>{}</div>;
};

export default items;
