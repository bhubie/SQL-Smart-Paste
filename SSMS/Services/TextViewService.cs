using System;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;

namespace SqlSmartCopyPaste.Services
{
    public class TextViewService
    {
        async public static void PasteTextToTextView(IAsyncServiceProvider serviceProvider, string text)
        {
            var textManager = await serviceProvider.GetServiceAsync(typeof(SVsTextManager)) as IVsTextManager;
            var componentModel = await serviceProvider.GetServiceAsync(typeof(SComponentModel)) as IComponentModel;
            var editor = componentModel.GetService<IVsEditorAdaptersFactoryService>();

            IVsTextView textViewCurrent;
            textManager.GetActiveView(1, null, out textViewCurrent);

            var wpfTextView = editor.GetWpfTextView(textViewCurrent);

            var caretPosition = GetCaretPosition(wpfTextView);

            var edit = wpfTextView.TextBuffer.CreateEdit();
            edit.Insert(caretPosition, text);
            edit.Apply();
        }

        public static IWpfTextView GetTextView(IAsyncServiceProvider serviceProvider)
        {
            var textManager = (IVsTextManager)serviceProvider.GetServiceAsync(typeof(SVsTextManager));
            var componentModel = (IComponentModel)serviceProvider.GetServiceAsync(typeof(SComponentModel));
            var editor = componentModel.GetService<IVsEditorAdaptersFactoryService>();

            IVsTextView textViewCurrent;
            textManager.GetActiveView(1, null, out textViewCurrent);

            return editor.GetWpfTextView(textViewCurrent);
        }


        public static int GetCaretPosition(IWpfTextView wpfTextView)
        {
            return wpfTextView.Caret.Position.BufferPosition.Position;
        }
    }
}
