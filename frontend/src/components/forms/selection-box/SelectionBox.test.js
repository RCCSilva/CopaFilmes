import React from 'react';
import { render, cleanup } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import SelectionBox from './SelectionBox';

afterEach(cleanup);

test('Test title and year are correctly created', () => {
    const testTitle = 'One title to test';
    const testYear = '1984';

    const { getByTestId } = render(<SelectionBox title={testTitle} year={testYear}/>);

    expect(getByTestId('title')).toHaveTextContent(testTitle);
    expect(getByTestId('year')).toHaveTextContent(testYear);
});