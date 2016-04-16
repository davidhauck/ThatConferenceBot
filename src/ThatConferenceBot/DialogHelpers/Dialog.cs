using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Bot.Builder.Dialogs;
using System.Web;
using Microsoft.Bot.Builder.Luis;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace ThatConferenceBot.DialogHelpers
{
	[LuisModel("fad8bfad-1a75-44c3-a2b8-0d9508486f6f", "c2ffbf490876429f8a88a96b8d2c6ab2")]
	[Serializable]
	public class SimpleDialog : LuisDialog<object>
	{
		public override Task StartAsync(IDialogContext context)
		{
			return base.StartAsync(context);
		}

		protected override Task MessageReceived(IDialogContext context, IAwaitable<Message> item)
		{
			return base.MessageReceived(context, item);
		}

		[LuisIntent("Book Campsite")]
		public async Task BookCampsite(IDialogContext context, LuisResult result)
		{
			;
		}

		[LuisIntent("None")]
		public async Task None(IDialogContext context, LuisResult result)
		{
			;
		}
	}
}