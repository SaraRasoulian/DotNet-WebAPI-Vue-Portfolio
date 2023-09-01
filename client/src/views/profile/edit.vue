<template>
    <div class="content-container">
        <div class="title-wrapper">
            <RouterLink to="/profile" class="back-to-list-wrapper" data-toggle="tooltip" data-placement="top"
                title="Return to view">
                <div class="back-to-list">
                    <img src="@/assets/images/back.png" class="back-icon" alt="" />
                </div>
            </RouterLink>
            <h4>Edit Profile</h4>
        </div>
        <hr class="line" />

        <div class="content">
            <div class="form-container">
                <form class="needs-validation" novalidate="">

                    <div class="row g-3">
                        <div class="col-lg-4 col-md-6 col-sm-12">
                            <label for="startYear" class="form-label">First Name</label>
                            <input type="text" class="form-control" placeholder="First Name" value="" required="">
                            <div class="invalid-feedback">
                                Valid first name is required.
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-sm-12">
                            <label for="endYear" class="form-label">Last Name</label>
                            <input type="text" class="form-control" placeholder="Last Name" value="" required="">
                            <div class="invalid-feedback">
                                Valid last name is required.
                            </div>
                        </div>
                    </div>

                    <div class="row g-3">
                        <div class="col-lg-8 col-md-12 col-sm-12">
                            <label for="degree" class="form-label">Email</label>
                            <div class="input-group has-validation">
                                <input type="text" class="form-control" placeholder="Email" required="" value="">
                                <div class="invalid-feedback">
                                    Your username is required.
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row g-3">
                        <div class="col-lg-8 col-md-12 col-sm-12">
                            <label for="field" class="form-label">Headline</label>
                            <input type="text" class="form-control" placeholder="Headline" value="">
                            <div class="invalid-feedback">
                                Please enter a valid email address for shipping updates.
                            </div>
                        </div>
                    </div>

                    <div class="row g-3">
                        <div class="col-lg-8 col-md-12 col-sm-12">
                            <label for="discription" class="form-label">About</label>
                            <textarea type="text" class="form-control" placeholder="About"></textarea>
                        </div>
                    </div>

                    <div class="row g-3">
                        <div class="col-lg-8 col-md-12 col-sm-12">
                            <label for="discription" class="form-label">Photo
                                <span class="secondary-text">(Optional)</span>
                            </label>
                            <div class="edit-photo-wrapper">
                                <img src="assets/images/profile-photo.png" class="view-profile-photo" alt="" />
                                <div class="photo-buttons-wrapper">
                                    <div>
                                        <button class="photo-btn update-btn" type="button">Update</button>
                                        <button class="photo-btn remove-btn" type="button">Remove</button>
                                    </div>
                                    <span class="secondary-text">Recommended: Square JPG, PNG, or GIF, at least 1,000 pixels
                                        per side.</span>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6 col-md-8 col-sm-12 col-xs-12">
                            <div class="button-container">
                                <button class="btn btn-save" type="submit">Save</button>
                                <RouterLink to="/profile" class="btn btn-cancel">Cancel</RouterLink>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>