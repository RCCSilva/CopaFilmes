import React from 'react';
import { render, cleanup } from '@testing-library/react';
import Header from './Header';
import '@testing-library/jest-dom/extend-expect';

afterEach(cleanup);

test('renders Header super title', () => {
    const { getByTestId } = render(<Header/>);

    expect(getByTestId('header-supertitle')).toHaveTextContent('CAMPEONATO DE FILMES');
});

test('renders Header with correct title', () => {
    const testTitle = 'One title to rule them all';

    const { getByTestId } = render(<Header title={testTitle}/>);

    expect(getByTestId('header-title')).toHaveTextContent(testTitle);
});

test('renders Header with correct subtitle', () => {
    const testSubTitle = 'Another subtitle...'; 

    const { getByTestId } = render(<Header subTitle={testSubTitle}/>);

    expect(getByTestId('header-subtitle')).toHaveTextContent(testSubTitle);
});
