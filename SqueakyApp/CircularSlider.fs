namespace SqueakyApp

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open CC
open Xamarin.Forms

module ViewAttributes =
    let circularSliderKnobColorAttributeKey =
        AttributeKey<Color> "CircularSlider_KnobColor"

    let circularSliderTrackProgressColorAttributeKey =
        AttributeKey<Color> "CircularSlider_TrackProgressColor"

    let circularSliderValueAttributeKey =
        AttributeKey<float> "CircularSlider_Value"

    let circularSliderArcAttributeKey = AttributeKey<float> "CircularSlider_Arc"

    let circularSliderStartAttributeKey =
        AttributeKey<float> "CircularSlider_Start"

    let circularSliderTrackWidthAttributeKey =
        AttributeKey<float> "CircularSlider_TrackWidth"

    let circularSliderTrackProgressWidthAttributeKey =
        AttributeKey<float> "CircularSlider_TrackProgressWidth"

    let circularSliderTrackColorAttributeKey =
        AttributeKey<Color> "CircularSlider_TrackColor"

    let circularSliderMinimumAttributeKey =
        AttributeKey<float> "CircularSlider_Minimum"

    let circularSliderMaximumAttributeKey =
        AttributeKey<float> "CircularSlider_Maximum"

    let circularSliderValueChangedAttributeKey =
        AttributeKey<CircularSlider.ValueChangedHandler> "CircularSlider_ValueChanged"


open ViewAttributes

type ViewBuilders =

    static member CreateCircularSlider() : CircularSlider = CircularSlider()

    static member UpdateViewAttachedProperties
        (
            propertyKey: int,
            prevOpt: ViewElement voption,
            curr: ViewElement,
            target: obj
        ) =
        ViewBuilders.UpdateVisualElementAttachedProperties(propertyKey, prevOpt, curr, target)

    static member BuildCircularSlider
        (
            attribCount,
            ?onValueChanged,
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

        let attribBuilder =
            ViewBuilders.BuildView(attribCount, ?created = created, ?width = width, ?height = height)

        match trackProgressColor with
        | None -> ()
        | Some v -> attribBuilder.Add(circularSliderTrackProgressColorAttributeKey, v)

        match knobColor with
        | None -> ()
        | Some v -> attribBuilder.Add(circularSliderKnobColorAttributeKey, v)

        match value with
        | None -> ()
        | Some v -> attribBuilder.Add(circularSliderValueAttributeKey, v)

        match arc with
        | None -> ()
        | Some v -> attribBuilder.Add(circularSliderArcAttributeKey, v)

        match start with
        | None -> ()
        | Some v -> attribBuilder.Add(circularSliderStartAttributeKey, v)

        match trackWidth with
        | None -> ()
        | Some v -> attribBuilder.Add(circularSliderTrackWidthAttributeKey, v)

        match trackProgressWidth with
        | None -> ()
        | Some v -> attribBuilder.Add(circularSliderTrackProgressWidthAttributeKey, v)

        match trackColor with
        | None -> ()
        | Some v -> attribBuilder.Add(circularSliderTrackColorAttributeKey, v)


        match minimum with
        | None -> ()
        | Some v -> attribBuilder.Add(circularSliderMinimumAttributeKey, v)

        match maximum with
        | None -> ()
        | Some v -> attribBuilder.Add(circularSliderMaximumAttributeKey, v)

        match onValueChanged with
        | None -> ()
        | Some v ->
            attribBuilder.Add(
                circularSliderValueChangedAttributeKey,
                (fun f -> CircularSlider.ValueChangedHandler(fun _sender _args -> f _args)) v
            )

        attribBuilder

    static member UpdateCircularSlider(prevOpt: ViewElement voption, curr: ViewElement, target: CircularSlider) =
        let mutable prevValueChangedOpt = ValueNone
        let mutable currValueChangedOpt = ValueNone
        let mutable prevArcOpt = ValueNone
        let mutable currArcOpt = ValueNone
        let mutable prevStartOpt = ValueNone
        let mutable currStartOpt = ValueNone
        let mutable prevValueOpt = ValueNone
        let mutable currValueOpt = ValueNone
        let mutable prevTrackProgressColorOpt = ValueNone
        let mutable currTrackProgressColorOpt = ValueNone
        let mutable prevMinimumOpt = ValueNone
        let mutable currMinimumOpt = ValueNone
        let mutable prevMaximumOpt = ValueNone
        let mutable currMaximumOpt = ValueNone
        let mutable prevKnobColorOpt = ValueNone
        let mutable currKnobColorOpt = ValueNone
        let mutable prevTrackColorOpt = ValueNone
        let mutable currTrackColorOpt = ValueNone
        let mutable prevTrackWidthOpt = ValueNone
        let mutable currTrackWidthOpt = ValueNone
        let mutable prevTrackProgressWidthOpt = ValueNone
        let mutable currTrackProgressWidthOpt = ValueNone

        for kvp in curr.AttributesKeyed do
            if kvp.Key = circularSliderValueChangedAttributeKey.KeyValue then
                currValueChangedOpt <- ValueSome(kvp.Value :?> CircularSlider.ValueChangedHandler)

            if kvp.Key = circularSliderTrackProgressColorAttributeKey.KeyValue then
                currTrackProgressColorOpt <- ValueSome(kvp.Value :?> Color)

            if kvp.Key = circularSliderValueAttributeKey.KeyValue then
                currValueOpt <- ValueSome(kvp.Value :?> float)

            if kvp.Key = circularSliderArcAttributeKey.KeyValue then
                currArcOpt <- ValueSome(kvp.Value :?> float)

            if kvp.Key = circularSliderStartAttributeKey.KeyValue then
                currStartOpt <- ValueSome(kvp.Value :?> float)

            if kvp.Key = circularSliderMinimumAttributeKey.KeyValue then
                currMinimumOpt <- ValueSome(kvp.Value :?> float)

            if kvp.Key = circularSliderMaximumAttributeKey.KeyValue then
                currMaximumOpt <- ValueSome(kvp.Value :?> float)

            if kvp.Key = circularSliderKnobColorAttributeKey.KeyValue then
                currKnobColorOpt <- ValueSome(kvp.Value :?> Color)

            if kvp.Key = circularSliderTrackColorAttributeKey.KeyValue then
                currTrackColorOpt <- ValueSome(kvp.Value :?> Color)

            if kvp.Key = circularSliderTrackWidthAttributeKey.KeyValue then
                currTrackWidthOpt <- ValueSome(kvp.Value :?> float)

            if kvp.Key = circularSliderTrackProgressWidthAttributeKey.KeyValue then
                currTrackProgressWidthOpt <- ValueSome(kvp.Value :?> float)

        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = circularSliderValueChangedAttributeKey.KeyValue then
                    prevValueChangedOpt <- ValueSome(kvp.Value :?> CircularSlider.ValueChangedHandler)

                if kvp.Key = circularSliderTrackProgressColorAttributeKey.KeyValue then
                    prevTrackProgressColorOpt <- ValueSome(kvp.Value :?> Color)

                if kvp.Key = circularSliderValueAttributeKey.KeyValue then
                    prevValueOpt <- ValueSome(kvp.Value :?> float)

                if kvp.Key = circularSliderArcAttributeKey.KeyValue then
                    prevArcOpt <- ValueSome(kvp.Value :?> float)

                if kvp.Key = circularSliderStartAttributeKey.KeyValue then
                    prevStartOpt <- ValueSome(kvp.Value :?> float)

                if kvp.Key = circularSliderMinimumAttributeKey.KeyValue then
                    prevMinimumOpt <- ValueSome(kvp.Value :?> float)

                if kvp.Key = circularSliderMaximumAttributeKey.KeyValue then
                    prevMaximumOpt <- ValueSome(kvp.Value :?> float)

                if kvp.Key = circularSliderKnobColorAttributeKey.KeyValue then
                    prevKnobColorOpt <- ValueSome(kvp.Value :?> Color)

                if kvp.Key = circularSliderTrackColorAttributeKey.KeyValue then
                    prevTrackColorOpt <- ValueSome(kvp.Value :?> Color)

                if kvp.Key = circularSliderTrackWidthAttributeKey.KeyValue then
                    prevTrackWidthOpt <- ValueSome(kvp.Value :?> float)

                if kvp.Key = circularSliderTrackProgressWidthAttributeKey.KeyValue then
                    prevTrackProgressWidthOpt <- ValueSome(kvp.Value :?> float)

        match struct (prevValueOpt, currValueOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (_, ValueSome currValue) -> target.Value <- currValue
        | struct (ValueSome _, ValueNone) -> target.ClearValue CircularSlider.ValueProperty
        | struct (ValueNone, ValueNone) -> ()

        match struct (prevArcOpt, currArcOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (_, ValueSome currValue) -> target.Arc <- currValue
        | struct (ValueSome _, ValueNone) -> target.ClearValue CircularSlider.ArcProperty
        | struct (ValueNone, ValueNone) -> ()

        match struct (prevStartOpt, currStartOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (_, ValueSome currValue) -> target.Start <- currValue
        | struct (ValueSome _, ValueNone) -> target.ClearValue CircularSlider.StartProperty
        | struct (ValueNone, ValueNone) -> ()

        match struct (prevTrackProgressColorOpt, currTrackProgressColorOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (_, ValueSome currValue) -> target.TrackProgressColor <- currValue
        | struct (ValueSome _, ValueNone) -> target.ClearValue CircularSlider.TrackProgressColorProperty
        | struct (ValueNone, ValueNone) -> ()

        match struct (prevMinimumOpt, currMinimumOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (_, ValueSome currValue) -> target.Minimum <- currValue
        | struct (ValueSome _, ValueNone) -> target.ClearValue CircularSlider.MinimumProperty
        | struct (ValueNone, ValueNone) -> ()

        match struct (prevMaximumOpt, currMaximumOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (_, ValueSome currValue) -> target.Maximum <- currValue
        | struct (ValueSome _, ValueNone) -> target.ClearValue CircularSlider.MaximumProperty
        | struct (ValueNone, ValueNone) -> ()

        match struct (prevKnobColorOpt, currKnobColorOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (_, ValueSome currValue) -> target.KnobColor <- currValue
        | struct (ValueSome _, ValueNone) -> target.ClearValue CircularSlider.KnobColorProperty
        | struct (ValueNone, ValueNone) -> ()

        match struct (prevTrackColorOpt, currTrackColorOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (_, ValueSome currValue) -> target.TrackColor <- currValue
        | struct (ValueSome _, ValueNone) -> target.ClearValue CircularSlider.TrackColorProperty
        | struct (ValueNone, ValueNone) -> ()

        match struct (prevTrackWidthOpt, currTrackWidthOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (_, ValueSome currValue) -> target.TrackWidth <- currValue
        | struct (ValueSome _, ValueNone) -> target.ClearValue CircularSlider.TrackWidthProperty
        | struct (ValueNone, ValueNone) -> ()

        match struct (prevTrackProgressWidthOpt, currTrackProgressWidthOpt) with
        | struct (ValueSome prevValue, ValueSome currValue) when prevValue = currValue -> ()
        | struct (_, ValueSome currValue) -> target.TrackProgressWidth <- currValue
        | struct (ValueSome _, ValueNone) -> target.ClearValue CircularSlider.TrackProgressWidthProperty
        | struct (ValueNone, ValueNone) -> ()
        // Unsubscribe previous event handlers
        let shouldUpdateTimeChanged =
            not (
                identicalVOption prevValueChangedOpt currValueChangedOpt
                && (identicalVOption prevValueOpt currValueOpt)
            )

        if shouldUpdateTimeChanged then
            match prevValueChangedOpt with
            | ValueSome prevValue -> target.OnValueChanged.RemoveHandler(prevValue)
            | ValueNone -> ()
        // Update inherited members
        ViewBuilders.UpdateView(prevOpt, curr, target)
        // Subscribe new event handlers
        if shouldUpdateTimeChanged then
            match currValueChangedOpt with
            | ValueSome currValue -> target.OnValueChanged.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructCircularSlider
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
        let attribBuilder =
            ViewBuilders.BuildCircularSlider(
                0,
                ?onValueChanged = onValueChanged,
                ?created = created,
                ?width = width,
                ?height = height,
                ?minimum = minimum,
                ?maximum = maximum,
                ?trackWidth = trackWidth,
                ?trackProgressWidth = trackProgressWidth,
                ?trackColor = trackColor,
                ?trackProgressColor = trackProgressColor,
                ?knobColor = knobColor,
                ?value = value,
                ?arc = arc,
                ?start = start
            )

        ViewElement.Create<CircularSlider>(
            ViewBuilders.CreateCircularSlider,
            (fun prev curr target -> ViewBuilders.UpdateCircularSlider(prev, curr, target)),
            (fun key prev curr target -> ViewBuilders.UpdateViewAttachedProperties(key, prev, curr, target)),
            attribBuilder
        )


[<AutoOpen>]
module CircularSlider =

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

            ViewBuilders.ConstructCircularSlider(
                ?onValueChanged = onValueChanged,
                ?created = created,
                ?width = width,
                ?height = height,
                ?minimum = minimum,
                ?maximum = maximum,
                ?trackWidth = trackWidth,
                ?trackProgressWidth = trackProgressWidth,
                ?trackColor = trackColor,
                ?trackProgressColor = trackProgressColor,
                ?knobColor = knobColor,
                ?value = value,
                ?arc = arc,
                ?start = start
            )
