'use strict';
// The module 'vscode' contains the VS Code extensibility API
// Import the module and reference it with the alias vscode in your code below
import * as vscode from 'vscode';
import { formatText } from './formatText';

// The module 'azdata' contains the Azure Data Studio extensibility API
// This is a complementary set of APIs that add SQL / Data-specific functionality to the app
// Import the module and reference it with the alias azdata in your code below

import * as azdata from 'azdata';

// this method is called when your extension is activated
// your extension is activated the very first time the command is executed

async function formatClipboardTextAndPasteToEditor(formatAsString: boolean) {
    const clipboardContent = await vscode.env.clipboard.readText();
    const formattedText = formatText(clipboardContent, formatAsString);
    
    const editor = vscode.window.activeTextEditor;
    if (editor) {
        editor.edit(editBuilder => {
            editBuilder.insert(editor.selection.active, formattedText);
        });
    }
}

export function activate(context: vscode.ExtensionContext) {

   
    // The command has been defined in the package.json file
    // Now provide the implementation of the command with  registerCommand
    // The commandId parameter must match the command field in package.json
    context.subscriptions.push(vscode.commands.registerCommand('sql-smart-paste.pasteascsv', async () => {
        await formatClipboardTextAndPasteToEditor(false);
    }));

    context.subscriptions.push(vscode.commands.registerCommand('sql-smart-paste.pasteasvarcharcsv', async () => {
        await formatClipboardTextAndPasteToEditor(true);
    }));
}

// this method is called when your extension is deactivated
export function deactivate() {
}