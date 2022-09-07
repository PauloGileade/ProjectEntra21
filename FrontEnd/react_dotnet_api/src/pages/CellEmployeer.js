import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";
import { useEffect, useState } from "react";
import { Table, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import HeaderPlatform from "../components/HeaderPlatform/HeaderPlatform";
import { useParams } from "react-router-dom";
import "./global.css";

function CellEmployeer() {
  const baseUrl = "https://localhost:5001/api/CellEmployeers";
  const [data, setData] = useState([]);
  const [modalExcluir, setModalExcluir] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);

  let codecell = useParams().codeCell;
  let date = useParams().date;

  const [cellEmployeerselect, setCellEmployeerSelect] = useState({
    cell: "",
    registerEmployeer: "",
    phase: "",
  });

  const selectCellEmployeer = (cellEmployeer, opcao) => {
    setCellEmployeerSelect(cellEmployeer);
    opcao === "Editar" ? abrirFecharModalEditar() : abrirFecharModalExcluir();
  };

  const abrirFecharModalExcluir = () => {
    setModalExcluir(!modalExcluir);
  };

  const abrirFecharModalEditar = () => {
    setModalEditar(!modalEditar);
  };

  const pedidoDelete = async () => {
    await axios
      .delete(baseUrl + "/" + cellEmployeerselect.code)
      .then((response) => {
        setData(
          data.filter(
            (cellEmployeer) => cellEmployeer.code !== cellEmployeerselect.code
          )
        );
        abrirFecharModalExcluir();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const pedidoGetByCellEmployeer = async () => {
    await axios
      .get(baseUrl + "/" + codecell + "/" + date)
      .then((response) => {
        console.log(response);
        setData(response.data.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  useEffect(() => {
    pedidoGetByCellEmployeer();
  }, []);

  return (
    <div>
      <HeaderPlatform />
      <main className="main__global">
        <div className="container">
          <h2>Operações</h2>
          <Table bordered hover responsive size="sm">
            <thead className="table__order">
              <tr align="center">
                <th>Codigo</th>
                <th>Celula</th>
                <th>Matricula</th>
                <th>Nome</th>
                <th>Função</th>
                <th>Nivel</th>
                <th>Fase</th>
                <th>Operação</th>
              </tr>
            </thead>
            <tbody>
              {data.map((cellEmployeer) => (
                <tr
                  className="table__painel"
                  align="center"
                  key={cellEmployeer.code}
                >
                  <td>{cellEmployeer.code}</td>
                  <td>{cellEmployeer.cell}</td>
                  <td>{cellEmployeer.registerEmployeer}</td>
                  <td>{cellEmployeer.nameEmployeer}</td>
                  <td>{cellEmployeer.office}</td>
                  <td>{cellEmployeer.levelEmployeer}</td>
                  <td>{cellEmployeer.phase}</td>
                  <td>
                    <button
                      className="btn btn-danger"
                      onClick={() =>
                        selectCellEmployeer(cellEmployeer, "Excluir")
                      }
                    >
                      Excluir
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>

          <Modal isOpen={modalExcluir}>
            <ModalBody>
              Confirma a exclusão desta (a) Operação :{" "}
              {cellEmployeerselect && cellEmployeerselect.code} ?
            </ModalBody>
            <ModalFooter>
              <button
                className="btn btn-primary"
                onClick={() => pedidoDelete()}
              >
                {"  "}
                Sim
              </button>
              <button
                className="btn btn-danger"
                onClick={() => abrirFecharModalExcluir()}
              >
                Não
              </button>
            </ModalFooter>
          </Modal>
        </div>
      </main>
    </div>
  );
}

export default CellEmployeer;
