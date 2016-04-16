using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MyFirstBotApplication.Enums;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;

namespace MyFirstBotApplication.Helpers
{
	[Serializable]
	public class ReservationForm
	{
		public DateTime? ReservationStartDate { get; set; }
		public DateTime? ReservationEndDate { get; set; }
		public Campsite Campsite { get; set; }

		public static IForm<ReservationForm> BuildForm()
		{
			return new FormBuilder<ReservationForm>()
				.Message("We will create you a reservation!")
				.Field(nameof(ReservationForm.Campsite))
				.Field(nameof(ReservationForm.ReservationStartDate))
				.Field(nameof(ReservationForm.ReservationEndDate))
				.AddRemainingFields()
				.Message("Thanks for reserving a campsite!")
				.OnCompletionAsync(MakeReservation)
				.Build();
		}

		private static Task MakeReservation(IDialogContext context, ReservationForm state)
		{
			throw new NotImplementedException();
		}
	}
}