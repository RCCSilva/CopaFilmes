import React from 'react';
import { render, cleanup } from '@testing-library/react';
import CheckBox from './CheckBox';
import '@testing-library/jest-dom/extend-expect';
import { 
    selectedStyle
} from './CheckBox.style';

afterEach(cleanup);

test('renders CheckBox without selectedStyle if selected is false', () => {
    const { getByTestId } = render(<CheckBox selected={false}/>);

    expect(getByTestId('checkbox')).not.toHaveClass(selectedStyle);
});

test('renders CheckBox with selectedStyle if selected is true', () => {
    const { getByTestId } = render(<CheckBox selected={true}/>);

    expect(getByTestId('checkbox')).toHaveClass(selectedStyle);
});