namespace SqueakyApp

open Fabulous
open Fabulous.XamarinForms
open CC
open Xamarin.Forms

[<AutoOpen>]
module CircularSlider =
    let circularSliderKnobColorAttributeKey =
        AttributeKey<_> "CircularSlider_KnobColor"

    let circularSliderTrackProgressColorAttributeKey =
        AttributeKey<_> "CircularSlider_TrackProgressColor"

    let circularSliderValueAttributeKey = AttributeKey<_> "CircularSlider_Value"

    let circularSliderArcAttributeKey = AttributeKey<_> "CircularSlider_Arc"

    let circularSliderStartAttributeKey = AttributeKey<_> "CircularSlider_Start"

    let circularSliderTrackWidthAttributeKey =
        AttributeKey<_> "CircularSlider_TrackWidth"

    let circularSliderTrackProgressWidthAttributeKey =
        AttributeKey<_> "CircularSlider_TrackProgressWidth"

    let circularSliderTrackColorAttributeKey =
        AttributeKey<Color> "CircularSlider_TrackColor"

    let circularSliderMinimumAttributeKey = AttributeKey<_> "CircularSlider_Minimum"

    let circularSliderMaximumAttributeKey = AttributeKey<_> "CircularSlider_Maximum"

    let circularSliderValueChangedAttributeKey =
        AttributeKey<CircularSlider.ValueChangedHandler> "CircularSlider_ValueChanged"

    type Fabulous.XamarinForms.View with
        static member inline CircularSlider
            (
                ?onValueChanged: ValueChangedEventArgs -> unit,
                ?created,
                ?width,
                ?height,
                ?minimum,
                ?maximum,
                ?trackWidth,
                ?trackProgressWidth,
                ?trackColor,
                ?trackProgressColor,
                ?knobColor,
                ?value,
                ?arc,
                ?start
            ) =

            let attribCount = 0

            let attribCount =
                match trackProgressColor with
                | Some _ -> attribCount + 1
                | None -> attribCount

            let attribCount =
                match knobColor with
                | Some _ -> attribCount + 1
                | None -> attribCount

            let attribCount =
                match value with
                | Some _ -> attribCount + 1
                | None -> attribCount

            let attribCount =
                match arc with
                | Some _ -> attribCount + 1
                | None -> attribCount

            let attribCount =
                match start with
                | Some _ -> attribCount + 1
                | None -> attribCount

            let attribCount =
                match trackWidth with
                | Some _ -> attribCount + 1
                | None -> attribCount

            let attribCount =
                match trackProgressWidth with
                | Some _ -> attribCount + 1
                | None -> attribCount

            let attribCount =
                match trackColor with
                | Some _ -> attribCount + 1
                | None -> attribCount

            let attribCount =
                match onValueChanged with
                | Some _ -> attribCount + 1
                | None -> attribCount

            let attribCount =
                match minimum with
                | Some _ -> attribCount + 1
                | None -> attribCount

            let attribCount =
                match maximum with
                | Some _ -> attribCount + 1
                | None -> attribCount

            let attribs =
                ViewBuilders.BuildView(attribCount, ?created = created, ?width = width, ?height = height)

            match trackProgressColor with
            | None -> ()
            | Some v -> attribs.Add(circularSliderTrackProgressColorAttributeKey, v)

            match knobColor with
            | None -> ()
            | Some v -> attribs.Add(circularSliderKnobColorAttributeKey, v)

            match value with
            | None -> ()
            | Some v -> attribs.Add(circularSliderValueAttributeKey, v)

            match arc with
            | None -> ()
            | Some v -> attribs.Add(circularSliderArcAttributeKey, v)

            match start with
            | None -> ()
            | Some v -> attribs.Add(circularSliderStartAttributeKey, v)

            match trackWidth with
            | None -> ()
            | Some v -> attribs.Add(circularSliderTrackWidthAttributeKey, v)

            match trackProgressWidth with
            | None -> ()
            | Some v -> attribs.Add(circularSliderTrackProgressWidthAttributeKey, v)

            match trackColor with
            | None -> ()
            | Some v -> attribs.Add(circularSliderTrackColorAttributeKey, v)


            match minimum with
            | None -> ()
            | Some v -> attribs.Add(circularSliderMinimumAttributeKey, v)

            match maximum with
            | None -> ()
            | Some v -> attribs.Add(circularSliderMaximumAttributeKey, v)

            match onValueChanged with
            | None -> ()
            | Some v ->
                attribs.Add(circularSliderValueChangedAttributeKey, CircularSlider.ValueChangedHandler(fun _ -> v))

            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: CircularSlider) =
                ViewBuilders.UpdateView(prevOpt, source, target)

                source.UpdatePrimitive(
                    prevOpt,
                    target,
                    circularSliderTrackProgressColorAttributeKey,
                    (fun target v -> target.TrackProgressColor <- v)
                )

                source.UpdatePrimitive(
                    prevOpt,
                    target,
                    circularSliderKnobColorAttributeKey,
                    (fun target v -> target.KnobColor <- v)
                )

                source.UpdatePrimitive(
                    prevOpt,
                    target,
                    circularSliderValueAttributeKey,
                    (fun target v -> target.Value <- v)
                )

                source.UpdatePrimitive(
                    prevOpt,
                    target,
                    circularSliderArcAttributeKey,
                    (fun target v -> target.Arc <- v)
                )

                source.UpdatePrimitive(
                    prevOpt,
                    target,
                    circularSliderStartAttributeKey,
                    (fun target v -> target.Start <- v)
                )

                source.UpdatePrimitive(
                    prevOpt,
                    target,
                    circularSliderTrackWidthAttributeKey,
                    (fun target v -> target.TrackWidth <- v)
                )

                source.UpdatePrimitive(
                    prevOpt,
                    target,
                    circularSliderTrackColorAttributeKey,
                    (fun target v -> target.TrackColor <- v)
                )

                source.UpdatePrimitive(
                    prevOpt,
                    target,
                    circularSliderTrackProgressWidthAttributeKey,
                    (fun target v -> target.TrackProgressWidth <- v)
                )

                source.UpdatePrimitive(
                    prevOpt,
                    target,
                    circularSliderMinimumAttributeKey,
                    (fun target v -> target.Minimum <- v)
                )

                source.UpdatePrimitive(
                    prevOpt,
                    target,
                    circularSliderMaximumAttributeKey,
                    (fun target v -> target.Maximum <- v)
                )

                source.UpdateEvent(prevOpt, circularSliderValueChangedAttributeKey, target.OnValueChanged)

            let updateAttachedProperties propertyKey prevOpt source target =
                ViewBuilders.UpdateViewAttachedProperties(propertyKey, prevOpt, source, target)

            ViewElement.Create(CircularSlider, update, updateAttachedProperties, attribs)
