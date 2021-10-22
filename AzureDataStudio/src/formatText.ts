export function formatText(text: string, formatAsString: boolean) {
    const splitText = text.split(/\r?\n/).filter(x => x !== '');

    const isTextAllNumeric = formatAsString ? false : isAllTextNumeric(splitText);

    return joinText(splitText, isTextAllNumeric);
}

function isAllTextNumeric(text: string[]): boolean {
    return text.every(t => parseInt(t));
}

function joinText(text: string[], isTextAllNumeric: boolean): string {
    
    return text.map((el) => {
        // Properly escape apostrophe
        let t = el.replace("'", "''");

        if (isTextAllNumeric)
        {
            return t;
        }
        else
        {
            return `'${t}'`;
        }
    }).join(',\n');
}