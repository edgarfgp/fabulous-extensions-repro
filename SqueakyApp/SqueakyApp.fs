// Copyright Fabulous contributors. See LICENSE.md for license.
namespace SqueakyApp

open System.Diagnostics
open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.LiveUpdate
open Xamarin.Forms

module App =
    type Model = { Amount: float }

    type Msg = LoanAmountChanged of float

    let initModel = { Amount = 100. }

    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | LoanAmountChanged amount ->
            let model = { model with Amount = amount }
            model, Cmd.none

    let view (model: Model) (dispatch: Msg -> unit) =
        View.ContentPage(
            content =
                View.StackLayout(
                    padding = Thickness 20.0,
                    verticalOptions = LayoutOptions.Center,
                    children =
                        [ View
                              .CircularSlider(
                                  width = 300.,
                                  height = 216.,
                                  trackProgressColor = Color.Red,
                                  knobColor = Color.Green,
                                  trackColor = Color.Gray,
                                  trackWidth = 15.,
                                  trackProgressWidth = 20.,
                                  arc = 310.,
                                  start = 115.,
                                  value = model.Amount,
                                  minimum = 0.,
                                  maximum = 1500.,
                                  onValueChanged = fun args -> dispatch (LoanAmountChanged args.NewValue)) ]
                )
        )

    // Note, this declaration is needed if you enable LiveUpdate
    let program =
        XamarinFormsProgram.mkProgram init update view
#if DEBUG
        |> Program.withConsoleTrace
#endif

type App() as app =
    inherit Application()

    let runner =
        App.program |> XamarinFormsProgram.run app

#if DEBUG
// Uncomment this line to enable live update in debug mode.
// See https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/tools.html#live-update for further  instructions.
//
//do runner.EnableLiveUpdate()
#endif

// Uncomment this code to save the application state to app.Properties using Newtonsoft.Json
// See https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/models.html#saving-application-state for further  instructions.
#if APPSAVE
    let modelId = "model"

    override __.OnSleep() =

        let json =
            Newtonsoft.Json.JsonConvert.SerializeObject(runner.CurrentModel)

        Console.WriteLine("OnSleep: saving model into app.Properties, json = {0}", json)

        app.Properties.[modelId] <- json

    override __.OnResume() =
        Console.WriteLine "OnResume: checking for model in app.Properties"

        try
            match app.Properties.TryGetValue modelId with
            | true, (:? string as json) ->

                Console.WriteLine("OnResume: restoring model from app.Properties, json = {0}", json)

                let model =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<App.Model>(json)

                Console.WriteLine("OnResume: restoring model from app.Properties, model = {0}", (sprintf "%0A" model))
                runner.SetCurrentModel(model, Cmd.none)

            | _ -> ()
        with
        | ex -> App.program.onError ("Error while restoring model found in app.Properties", ex)

    override this.OnStart() =
        Console.WriteLine "OnStart: using same logic as OnResume()"
        this.OnResume()
#endif
