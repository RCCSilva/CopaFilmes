import React from 'react';
import Header from '../components/header/Header';
import SelectionForm from '../components/forms/selection-form/SelectionForm';

const selectionTitle = 'Fase de Seleção';
const selectionSubTitle = 'Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir';

const SelectionView = props => {
    return (
        <div>
            <Header 
                title={selectionTitle}
                subTitle={selectionSubTitle}/>
            <SelectionForm
                createWoldCupHandler={props.createWoldCupHandler}/>
        </div>
    );
}

export default SelectionView;