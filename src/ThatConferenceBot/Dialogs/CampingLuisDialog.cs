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
	[LuisModel(Secrets.LuisId, Secrets.LuisKey )]
	[Serializable]
	public class CampingLuisDialog : LuisDialog<object>
	{
		[LuisIntent("Book Campsite")]
		public async Task BookCampsite(IDialogContext context, LuisResult result)
		{
			context.Call(FormDialog.FromForm(ReservationForm.BuildForm, FormOptions.PromptInStart), OnResumeFromBookCampsite);
		}

		private async Task OnResumeFromBookCampsite(IDialogContext context, IAwaitable<ReservationForm> result)
		{
			await context.PostAsync("What else would you like to do?");
			context.Wait(MessageReceived);
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