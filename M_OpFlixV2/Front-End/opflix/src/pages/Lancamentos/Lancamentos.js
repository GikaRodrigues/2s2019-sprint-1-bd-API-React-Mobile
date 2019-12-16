import React, { Component } from 'react';
import Axios from "axios";

export default class lancamentos extends Component{

    constructor(){
        super();
        this.state = {
            lista: []
        };
    }

    componentDidMount(){
        Axios.get('http://192.168.4.224:5000/api/Lancamentos',{
            headers: {
                Authorization: 'Bearer '+localStorage.getItem('usuario-opflix')
            }
        })
            .then(data => {
                this.setState({lista: data.data});
                console.log(this.state)
            })
            .catch(erro => {
                console.log(erro);
            });
        }

    render() {
        return(
            
                <div className="lancamentosCorpo">
                    
                            <table id="tabela-lista">
                                <thead>
                                    <tr>
                                        <th>Título</th>
                                        <th>Sinopse</th>
                                        <th>Tempo</th>
                                        <th>Tipo</th>
                                        <th>Data de lançamento</th>
                                        {/* <th>Categoria</th> */}
                                    </tr>
                                </thead>
                                <tbody id="tabelaListar">
                                    {this.state.lista.map(element => {
                                        return (
                                            <tr>
                                                <td>{element.titulo}</td>
                                                <td>{element.sinopse}</td>
                                                <td>{element.duracao}</td>
                                                <td>{element.tipo}</td>
                                                <td>{element.dataLancamento}</td>
                                                {/* <td>{element.idCategoriaNavigation}</td> */}
                                            </tr>
                                        )
                                    })}
                                </tbody>
                            </table>
                    </div>
        );
    }
}