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
			context.Call(MakeReservationDialog(), FinishedReservation);
		}

		private Task FinishedReservation(IDialogContext context, IAwaitable<object> result)
		{
			throw new NotImplementedException();
		}

		internal static IDialog<ReservationForm> MakeReservationDialog()
		{
			return Chain.From(() => FormDialog.FromForm(ReservationForm.BuildForm));
		}

		[LuisIntent("None")]
		public async Task None(IDialogContext context, LuisResult result)
		{
			await context.PostAsync("hi");
			context.Wait(MessageReceived);
		}
		
		[LuisIntent("Cancel Reservation")]
		public async Task CancelReservation(IDialogContext context, LuisResult result)
		{
			;
		}
	}
}