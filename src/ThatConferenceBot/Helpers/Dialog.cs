using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Bot.Builder.Dialogs;
using System.Web;
using Microsoft.Bot.Builder.Luis;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using MyFirstBotApplication.Helpers;
using Microsoft.Bot.Builder.FormFlow;

namespace ThatConferenceBot.Helpers
{
	[LuisModel("fad8bfad-1a75-44c3-a2b8-0d9508486f6f", "c2ffbf490876429f8a88a96b8d2c6ab2")]
	[Serializable]
	public class SimpleDialog : LuisDialog<object>
	{
		public const string ENTITY_DATETIME_DATE = "builtin.datetime.date";
		Message _message;

		public SimpleDialog(Message message)
		{
			_message = message;
		}

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
			await Conversation.SendAsync(_message, MakeReservationDialog);

			//EntityRecommendation date;
			//if (!result.TryFindEntity(ENTITY_DATETIME_DATE, out date))
			//{
			//	PromptDialog.Text(context, GotDate, "Please enter a date", "Didn't get that!");
			//}
		}
		
		internal static IDialog<ReservationForm> MakeReservationDialog()
		{
			return Chain.From(() => FormDialog.FromForm(ReservationForm.BuildForm));
		}

		[LuisIntent("None")]
		public async Task None(IDialogContext context, LuisResult result)
		{
			;
		}


		[LuisIntent("Cancel Reservation")]
		public async Task CancelReservation(IDialogContext context, LuisResult result)
		{
			;
		}
	}
}