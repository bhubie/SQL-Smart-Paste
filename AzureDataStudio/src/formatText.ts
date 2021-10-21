

export function formatText(text: string, formatAsString: boolean) {
    const splitText = text.split(/\r?\n/);

    const isTextAllNumeric = formatAsString ? false : isAllTextNumeric(splitText);
}

function isAllTextNumeric(text: string[]): boolean {
    return text.every(t => typeof t === 'number');
}