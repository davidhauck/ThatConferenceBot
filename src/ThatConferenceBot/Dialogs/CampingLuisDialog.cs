using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis.Models;
using ThatConferenceBot.Forms;
using Microsoft.Bot.Builder.FormFlow;

namespace ThatConferenceBot.Dialogs
{
	[LuisModel("fad8bfad-1a75-44c3-a2b8-0d9508486f6f", "c2ffbf490876429f8a88a96b8d2c6ab2")]
	[Serializable]
	public class CampingLuisDialog : LuisDialog<object>
	{
		public const string ENTITY_DATETIME_DATE = "builtin.datetime.date";
		public override Task StartAsync(IDialogContext context)
		{
			return base.StartAsync(context);
		}

		protected override Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
		{
			return base.MessageReceived(context, item);
		}

		[LuisIntent("Book Campsite")]
		public async Task BookCampsite(IDialogContext context, LuisResult result)
		{
			await context.PostAsync("Creating a campsite reservation. Please type anything to continue.");
			context.Call(FormDialog.FromForm(ReservationForm.BuildForm), OnResumeFromBookCampsite);
		}

		private async Task OnResumeFromBookCampsite(IDialogContext context, IAwaitable<ReservationForm> result)
		{
			await context.PostAsync("What else would you like to do?");
			context.Done<object>(null);
		}

		internal static IDialog<ReservationForm> MakeReservationDialog()
		{
			return Chain.From(() => FormDialog.FromForm(ReservationForm.BuildForm));
		}

		[LuisIntent("None")]
		public async Task None(IDialogContext context, LuisResult result)
		{
			await context.PostAsync("Could not understand command. Please try again.");
			context.Wait(MessageReceived);
		}

		[LuisIntent("Cancel Reservation")]
		public async Task CancelReservation(IDialogContext context, LuisResult result)
		{
			await context.PostAsync("Cancelling reservations not yet implemented");
		}
	}
}