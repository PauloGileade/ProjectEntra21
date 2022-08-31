import "bootstrap/dist/css/bootstrap.min.css";
import {
  Button,
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Table,
} from "reactstrap";
import axios from "axios";
import { useEffect, useState } from "react";
import HeaderPlatform from "../components/HeaderPlatform/HeaderPlatform";
import * as React from "react";

function Employeer() {
  const baseUrl = "https://localhost:5001/api/Employeers";

  const [data, setData] = useState([]);
  const [modalIncluir, setModalIncluir] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modalExcluir, setModalExcluir] = useState(false);
  const [modalFiltro, setModalFiltro] = useState(false);

  const [employeerselect, setEmployeerSelect] = useState({
    name: "",
    document: "",
    birthDate: "",
    office: "",
    levelEmployeer: "",
  });

  const [employeerselectbyregister, setEmployeerSelectByRegister] = useState({
    register: "",
  });

  const selectEmployeer = (employeer, opcao) => {
    setEmployeerSelect(employeer);
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

  const abrirFecharModalFiltro = () => {
    setModalFiltro(!modalFiltro);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEmployeerSelect({
      ...employeerselect,
      [name]: value,
    });
    console.log(employeerselect);
  };

  const handleChangeGet = (e) => {
    const { name, value } = e.target;
    setEmployeerSelectByRegister({
      ...employeerselectbyregister,
      [name]: value,
    });
    console.log(employeerselectbyregister);
  };

  const pedidoGetByRegister = async () => {
    await axios
      .get(baseUrl + "/" + employeerselectbyregister.register)
      .then((response) => {
        setData([response.data]);
        abrirFecharModalFiltro();
      })
      .catch((error) => {
        console.log(error);
      });
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

  useEffect(() => {
    pedidoGet();
  }, []);

  const pedidoPost = () => {
    axios
      .post(baseUrl, employeerselect)
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
      .put(baseUrl, employeerselect)
      .then((response) => {
        const update = [...data];
        update[update.map(u => u.register).indexOf(response.data.register)] = response.data
        setData(update);
        abrirFecharModalEditar();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const pedidoDelete = async () => {
    await axios
      .delete(baseUrl + "/" + employeerselect.register)
      .then((response) => {
        setData(
          data.filter(
            (employeer) => employeer.register !== employeerselect.register
          )
        );
        abrirFecharModalExcluir();
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div>
      <HeaderPlatform />
      <div className="container">
        <h2>Funcionarios</h2>
        <Button
          color="primary
        "
          outline
          className="btn"
          onClick={() => abrirFecharModalIncluir()}
        >
          Cadastrar Novo
        </Button>{" "}
        <Button
          color="primary
        "
          outline
          className="btn"
          onClick={() => abrirFecharModalFiltro()}
        >
          Buscar Por Matricula
        </Button>{" "}
        <div>
          <br />
        </div>
        <Table bordered hover responsive size="sm">
          <thead className="table-warning">
            <tr align="center">
              <th scope="col s12 m2">Matricula</th>
              <th scope="col s12 m2">Nome Completo</th>
              <th scope="col s12 m2">Documento</th>
              <th scope="col s12 m2">Data De Nascimento</th>
              <th scope="col s12 m2">Função</th>
              <th scope="col s12 m2">Nivel</th>
              <th scope="col s12 m2">Operação</th>
            </tr>
          </thead>
          <tbody className="table-light">
            {data &&
              data.map((employeer) => (
                <tr align="center" key={employeer.register}>
                  <td>{employeer.register}</td>
                  <td>{employeer.name}</td>
                  <td>{employeer.document}</td>
                  <td>{employeer.birthDate}</td>
                  <td>{employeer.office}</td>
                  <td>{employeer.levelEmployeer}</td>
                  <td>
                    <button
                      className="btn btn-primary"
                      onClick={() => selectEmployeer(employeer, "Editar")}
                    >
                      Editar
                    </button>
                    <button
                      className="btn btn-danger"
                      onClick={() => selectEmployeer(employeer, "Excluir")}
                    >
                      Excluir
                    </button>
                  </td>
                </tr>
              ))}
          </tbody>
        </Table>
        <Modal isOpen={modalIncluir}>
          <ModalHeader>Incluir Funcionario</ModalHeader>
          <ModalBody>
            <div className="form-group">
              <label>Nome:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="name"
                onChange={handleChange}
              ></input>
              <label>Documento:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="document"
                onChange={handleChange}
              ></input>
              <label>Data De Nascimento:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="birthDate"
                onChange={handleChange}
              ></input>
              <label>Função:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="office"
                onChange={handleChange}
              ></input>
              <label htmlFor="levelEmployeer">Nivel:</label>
              <br />
              <select
                type="text"
                className="form"
                name="levelEmployeer"
                onChange={handleChange}
              >
                <option value="">
                  <em></em>
                </option>
                <option>Junior</option>
                <option>Pleno</option>
                <option>Senior</option>
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
          <ModalHeader>Editar Funcionario</ModalHeader>
          <ModalBody>
            <div className="form-group">
              <label>Matricula:</label>
              <input
                type="text"
                className="form-control"
                readOnly
                value={employeerselect && employeerselect.register}
              />
              <br />
              <label>Nome:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="name"
                onChange={handleChange}
                value={employeerselect && employeerselect.name}
              ></input>
              <label>Documento:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="document"
                onChange={handleChange}
                value={employeerselect && employeerselect.document}
              ></input>
              <label>Data De Nascimento:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="birthDate"
                onChange={handleChange}
                value={employeerselect && employeerselect.birthDate}
              ></input>
              <label>Função:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="office"
                onChange={handleChange}
                value={employeerselect && employeerselect.office}
              ></input>
              <label htmlFor="levelEmployeer">Nivel:</label>
              <br />
              <select
                type="text"
                className="form"
                name="levelEmployeer"
                onChange={handleChange}
                value={employeerselect && employeerselect.levelEmployeer}
              >
                <option value="">
                  <em></em>
                </option>
                <option>Junior</option>
                <option>Pleno</option>
                <option>Senior</option>
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
        <Modal isOpen={modalFiltro}>
          <ModalHeader>Buscar Funcionario</ModalHeader>
          <ModalBody>
            <div className="form-group">
              <label>Matricula:</label>
              <br />
              <input
                type="text"
                className="form-control"
                name="register"
                onChange={handleChangeGet}
              ></input>
            </div>
          </ModalBody>

          <ModalFooter>
            <button
              className="btn btn-primary"
              onClick={() => pedidoGetByRegister()}
            >
              {" "}
              Buscar
            </button>
            <button
              className="btn btn-danger"
              onClick={() => abrirFecharModalFiltro()}
            >
              Cancelar
            </button>
          </ModalFooter>
        </Modal>
        <Modal isOpen={modalExcluir}>
          <ModalBody>
            Confirma a exclusão deste (a) Funcionario :{" "}
            {employeerselect && employeerselect.name} ?
          </ModalBody>
          <ModalFooter>
            <button className="btn btn-primary" onClick={() => pedidoDelete()}>
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
    </div>
  );
}

export default Employeer;
