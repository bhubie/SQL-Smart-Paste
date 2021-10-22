export function formatText(text: string, formatAsString: boolean) {
    const splitText = text.split(/\r?\n/).filter(x => x !== '');

    const isTextAllNumeric = formatAsString ? false : isAllTextNumeric(splitText);

    return joinText(splitText, isTextAllNumeric);
}

function isAllTextNumeric(text: string[]): boolean {
    return text.every(t => parseInt(t));
}

function joinText(text: string[], isTextAllNumeric: boolean): string {
    
    let joinedText: string = '';

    text.forEach((el, index, arr) => {
        // Properly Escape apostrophes
        let t = el.replace("'", "''");

        if (isTextAllNumeric)
        {
            joinedText += t;
        }
        else
        {
            joinedText += `'${t}'`;
        }

        if(!(index === arr.length - 1))
        {
            joinedText += ",";
            joinedText += "\n";
        }
    });

    return joinedText;
}