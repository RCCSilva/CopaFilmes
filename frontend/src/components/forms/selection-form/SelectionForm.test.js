import React from 'react';
import { render, cleanup } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import SelectionForm from './SelectionForm';
import { act } from 'react-dom/test-utils';

afterEach(cleanup);

test('if generate button is clicked before 8 items, show error message', () => {
    const { getByTestId } = render(<SelectionForm/>);

    const button = getByTestId('generate-button');

    act(() => {
        button.dispatchEvent(new MouseEvent('click', {bubbles: true}));
    });
    
    expect(getByTestId('error-message')).toHaveTextContent('Por favor, selecione 8 filmes antes de gerar o campeonato!');
});