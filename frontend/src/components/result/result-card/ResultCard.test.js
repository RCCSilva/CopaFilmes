import React from 'react';
import { render, cleanup } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import ResultCard from './ResultCard';

afterEach(cleanup);

test('test place value', () => {
    const place = '1º';

    const { getByTestId } = render(<ResultCard place={place}/>);

    expect(getByTestId('place')).toHaveTextContent(place);
});

test('test title value', () => {
    const title = 'One movie title, another movie title';

    const { getByTestId } = render(<ResultCard movieName={title}/>);

    expect(getByTestId('movieName')).toHaveTextContent(title);
});