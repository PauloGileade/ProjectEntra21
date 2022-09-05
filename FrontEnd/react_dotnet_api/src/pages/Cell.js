import "bootstrap/dist/css/bootstrap.min.css";
import axios from "axios";
import { useEffect, useState } from "react";
import {
  Button,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Table,
  Row,
} from "reactstrap";
import HeaderPlatform from "../components/HeaderPlatform/HeaderPlatform";
import "./global.css";

function Cell() {
  const baseUrl = "https://localhost:5001/api/Cells";

  const [data, setData] = useState([]);
  const [modalIncluir, setModalIncluir] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modalExcluir, setModalExcluir] = useState(false);

  const [cellselect, setCellSelect] = useState({
    status: "",
  });

  const selectCell = (cell, opcao) => {
    setCellSelect(cell);
    opcao === "Editar" ? abrirFecharModalEditar() : abrirFecharModalExcluir();
  };

  const abrirFecharModalIncluir = () => {
    setModalIncluir(!modalIncluir);
  };

  const abrirFecharModalEditar = () => {
    setModalEditar(!modalEditar);
  };

  const abrirFecharModalExcluir = () => {
    setModalExcluir(!modalExcluir);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCellSelect({
      ...cellselect,
      [name]: value,
    });
    console.log(cellselect);
  };

  const pedidoGet = async () => {
    await axios
      .get(baseUrl)
      .then((response) => {
        console.log(response);
        setData(response.data.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const pedidoPost = () => {
    axios
      .post(baseUrl, cellselect)
      .then((response) => {
        console.log({
          response,
        });
        setData(data.concat(response.data));
        abrirFecharModalIncluir();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const pedidoPut = async () => {
    await axios
      .put(baseUrl, cellselect)
      .then((response) => {
        const update = [...data];
        update[
          update.map((u) => u.statusCell).indexOf(response.data.statusCell)
        ] = response.data;
        setData(update);
        abrirFecharModalEditar();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const pedidoDelete = async () => {
    await axios
      .delete(baseUrl + "/" + cellselect.codeCell)
      .then((response) => {
        setData(
          data.filter((employeer) => employeer.codeCell !== cellselect.codeCell)
        );
        abrirFecharModalExcluir();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  useEffect(() => {
    pedidoGet();
  }, []);

  return (
    <div>
      <HeaderPlatform />
      <main className="main__global">
        <div className="container">
          <h2>Celulas</h2>
          <Button
            color="primary
        "
            outline
            className="btn"
            onClick={() => abrirFecharModalIncluir()}
          >
            Cadastrar Nova
          </Button>{" "}
          <div>
            <br />
          </div>
          <Row md="12" sm="2" xs="1">
            <Table bordered hover responsive size="sm">
              <thead className="table-warning">
                <tr align="center">
                  <th>Codigo</th>
                  <th>Status</th>
                  <th>Operação</th>
                </tr>
              </thead>
              <tbody className="table-light">
                {data.map((cell) => (
                  <tr align="center" key={cell.codeCell}>
                    <td>{cell.codeCell}</td>
                    <td>{cell.statusCell}</td>
                    <td>
                      <button
                        className="btn btn-primary"
                        onClick={() => selectCell(cell, "Editar")}
                      >
                        Editar
                      </button>
                      <button
                        className="btn btn-danger"
                        onClick={() => selectCell(cell, "Excluir")}
                      >
                        Excluir
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </Table>
          </Row>
          <Modal isOpen={modalIncluir}>
            <ModalHeader>Incluir Celula</ModalHeader>
            <ModalBody>
              <div className="form-group">
                <label htmlFor="type">Status:</label>
                <br />
                <select
                  type="text"
                  className="form"
                  name="statusCell"
                  onChange={handleChange}
                >
                  <option value="">
                    <em></em>
                  </option>
                  <option>Ativa</option>
                  <option>Finalizada</option>
                  <option>Bloqueada</option>
                </select>
              </div>
            </ModalBody>
            <ModalFooter>
              <button className="btn btn-primary" onClick={() => pedidoPost()}>
                {" "}
                Incluir
              </button>
              <button
                className="btn btn-danger"
                onClick={() => abrirFecharModalIncluir()}
              >
                Cancelar
              </button>
            </ModalFooter>
          </Modal>
          <Modal isOpen={modalEditar}>
            <ModalHeader>Editar Celula</ModalHeader>
            <ModalBody>
              <div className="form-group">
                <label>Codigo:</label>
                <input
                  type="text"
                  className="form-control"
                  readOnly
                  value={cellselect && cellselect.codeCell}
                />
                <br />
                <label htmlFor="type">Status:</label>
                <br />
                <select
                  type="text"
                  className="form"
                  name="statusCell"
                  onChange={handleChange}
                  value={cellselect && cellselect.statusCell}
                >
                  <option value="">
                    <em></em>
                  </option>
                  <option>Ativa</option>
                  <option>Finalizada</option>
                  <option>Bloqueada</option>
                </select>
              </div>
            </ModalBody>
            <ModalFooter>
              <button className="btn btn-primary" onClick={() => pedidoPut()}>
                {" "}
                Editar
              </button>
              <button
                className="btn btn-danger"
                onClick={() => abrirFecharModalEditar()}
              >
                Cancelar
              </button>
            </ModalFooter>
          </Modal>
          <Modal isOpen={modalExcluir}>
            <ModalBody>
              Confirma a exclusão deste (a) Celula :{" "}
              {cellselect && cellselect.codeCell} ?
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

export default Cell;
